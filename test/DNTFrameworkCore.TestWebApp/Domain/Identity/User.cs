using System;
using System.Collections.Generic;
using DNTFrameworkCore.Domain;

namespace DNTFrameworkCore.TestWebApp.Domain.Identity
{
    public class User : Entity<long>, IHasRowVersion, IHasRowIntegrity, ICreationTracking, IModificationTracking
    {
        public const int MaxUserNameLength = 256;
        public const int MaxDisplayNameLength = 50;
        public const int MaxPasswordHashLength = 256;
        public const int MaxPasswordLength = 128;
        public const int MaxSecurityTokenLength = 128;

        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string DisplayName { get; set; }
        public string NormalizedDisplayName { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastLoggedInDateTime { get; set; }
        public byte[] Version { get; set; }

        /// <summary>
        /// A random value that must change whenever a users credentials change (password,roles or permissions)
        /// </summary>
        public string SecurityToken { get; set; }

        public ICollection<UserRole> Roles { get; set; } = new HashSet<UserRole>();
        public ICollection<UserPermission> Permissions { get; set; } = new HashSet<UserPermission>();
        public ICollection<UserClaim> Claims { get; set; } = new HashSet<UserClaim>();

        public override string ToString() => UserName;

        public void ResetSecurityToken()
        {
            SecurityToken = NewSecurityToken();
        }

        public static string NewSecurityToken()
        {
            return Guid.NewGuid().ToString("N");
        }

        public static string NormalizeUserName(string userName)
        {
            return userName.ToUpperInvariant();
        }

        public static string NormalizeDisplayName(string userName)
        {
            return userName.ToUpperInvariant();
        }
    }
}