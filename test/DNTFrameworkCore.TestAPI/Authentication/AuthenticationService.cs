using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DNTFrameworkCore.Authorization;
using DNTFrameworkCore.Cryptography;
using DNTFrameworkCore.Dependency;
using DNTFrameworkCore.EFCore.Context;
using DNTFrameworkCore.Extensions;
using DNTFrameworkCore.Functional;
using DNTFrameworkCore.Runtime;
using DNTFrameworkCore.TestAPI.Domain.Identity;
using DNTFrameworkCore.TestAPI.Resources;
using DNTFrameworkCore.Web.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Claim = System.Security.Claims.Claim;

namespace DNTFrameworkCore.TestAPI.Authentication
{
    public interface IAuthenticationService : IScopedDependency
    {
        Task<SignInResult> SignInAsync(string userName, string password);
        Task SignOutAsync();
    }

    public sealed class AuthenticationService : IAuthenticationService
    {
        private readonly ITokenService _token;
        private readonly IDbContext _dbContext;
        private readonly IAntiXsrf _antiXsrf;
        private readonly IOptionsSnapshot<TokenOptions> _options;
        private readonly IMessageLocalizer _localizer;
        private readonly IUserPasswordHashAlgorithm _password;
        private readonly IUserSession _session;
        private readonly DbSet<User> _users;
        private readonly DbSet<Role> _roles;

        public AuthenticationService(
            ITokenService token,
            IDbContext dbContext,
            IAntiXsrf antiXsrf,
            IOptionsSnapshot<TokenOptions> options,
            IMessageLocalizer localizer,
            IUserPasswordHashAlgorithm password,
            IUserSession session)
        {
            _token = token ?? throw new ArgumentNullException(nameof(token));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _antiXsrf = antiXsrf ?? throw new ArgumentNullException(nameof(antiXsrf));
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
            _password = password ?? throw new ArgumentNullException(nameof(password));
            _session = session ?? throw new ArgumentNullException(nameof(session));

            _users = _dbContext.Set<User>();
            _roles = _dbContext.Set<Role>();
        }

        public async Task<SignInResult> SignInAsync(string userName, string password)
        {
            var maybe = await FindUserByNameAsync(userName);
            if (!maybe.HasValue)
            {
                return SignInResult.Fail(_localizer["SignIn.Messages.Failure"]);
            }

            var user = maybe.Value;

            if (_password.VerifyHashedPassword(user.PasswordHash, password) == PasswordVerificationResult.Failed)
            {
                return SignInResult.Fail(_localizer["SignIn.Messages.Failure"]);
            }

            if (!user.IsActive)
            {
                return SignInResult.Fail(_localizer["SignIn.Messages.IsNotActive"]);
            }

            var userId = user.Id;

            var claims = await BuildClaimsAsync(userId);
            var token = await _token.NewTokenAsync(userId, claims);
            _antiXsrf.AddToken(claims,JwtBearerDefaults.AuthenticationScheme);

            return SignInResult.Ok(token);
        }

        /// <summary>
        /// The Jwt implementation does not support "revoke OAuth token" (logout) by design.
        /// Delete the user's tokens from the database (revoke its bearer token)
        /// </summary>
        public async Task SignOutAsync()
        {
            await _token.RevokeTokensAsync(_session.UserId.FromString<long>());

            _antiXsrf.RemoveToken();
        }

        private async Task<IList<Claim>> BuildClaimsAsync(long userId)
        {
            var maybe = await FindUserIncludeClaimsAsync(userId);
            if (!maybe.HasValue) return new List<Claim>();

            var user = maybe.Value;

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString(), ClaimValueTypes.String,
                    _options.Value.Issuer),
                new Claim(JwtRegisteredClaimNames.Iss, _options.Value.Issuer, ClaimValueTypes.String,
                    _options.Value.Issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(),
                    ClaimValueTypes.Integer64, _options.Value.Issuer),
                new Claim(UserClaimTypes.UserId, user.Id.ToString(), ClaimValueTypes.Integer64,
                    _options.Value.Issuer),
                new Claim(UserClaimTypes.UserName, user.UserName, ClaimValueTypes.String,
                    _options.Value.Issuer),
                new Claim(UserClaimTypes.DisplayName, user.DisplayName, ClaimValueTypes.String,
                    _options.Value.Issuer),
                new Claim(UserClaimTypes.SecurityToken, user.SecurityToken, ClaimValueTypes.String,
                    _options.Value.Issuer)
            };

            foreach (var claim in user.Claims)
            {
                claims.Add(new Claim(claim.Type, claim.Value, ClaimValueTypes.String,
                    _options.Value.Issuer));
            }

            var roles = await FindUserRolesIncludeClaimsAsync(user.Id);
            foreach (var role in roles)
            {
                claims.Add(new Claim(UserClaimTypes.Role, role.Name, ClaimValueTypes.String,
                    _options.Value.Issuer));
            }

            var roleClaims = roles.SelectMany(a => a.Claims);
            foreach (var claim in roleClaims)
            {
                claims.Add(new Claim(claim.Type, claim.Value, ClaimValueTypes.String,
                    _options.Value.Issuer));
            }

            var rolePermissions = roles.SelectMany(a => a.Permissions).Select(a => a.Name);
            var grantedPermissions = user.Permissions.Where(p => p.IsGranted).Select(a => a.Name);
            var deniedPermissions = user.Permissions.Where(p => !p.IsGranted).Select(a => a.Name);

            var permissions = rolePermissions.Union(grantedPermissions).Except(deniedPermissions);

            //recommended approach to minimize size of  token/cookie
            claims.Add(new Claim(UserClaimTypes.PackedPermission,
                permissions.PackToString(PermissionConstant.PackingSymbol), ClaimValueTypes.String));

            return claims;
        }

        private async Task<Maybe<User>> FindUserIncludeClaimsAsync(long userId)
        {
            return await _users.Include(u => u.Permissions)
                .AsNoTracking()
                .Include(u => u.Claims)
                .FirstOrDefaultAsync(x => x.Id == userId);
        }

        private async Task<IList<Role>> FindUserRolesIncludeClaimsAsync(long userId)
        {
            var query = from role in _roles
                from userRoles in role.Users
                where userRoles.UserId == userId
                select role;

            return await query
                .AsNoTracking()
                .Include(r => r.Permissions)
                .Include(r => r.Claims)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        private async Task<Maybe<User>> FindUserByNameAsync(string userName)
        {
            var normalizedUserName = userName.ToUpperInvariant();

            return await _users.AsNoTracking()
                .FirstOrDefaultAsync(x => x.NormalizedUserName == normalizedUserName);
        }
    }
}