using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNTFrameworkCore.Common;
using DNTFrameworkCore.Dependency;
using DNTFrameworkCore.EFCore.Context;
using DNTFrameworkCore.TestAPI.Domain.Identity;
using Microsoft.EntityFrameworkCore;

namespace DNTFrameworkCore.TestAPI.Application.Common
{
    public interface ILookupService : IScopedDependency
    {
        Task<IReadOnlyList<LookupItem<long>>> FetchRolesAsync();
    }

    public class LookupService : ILookupService
    {
        private readonly IDbContext _dbContext;

        public LookupService(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IReadOnlyList<LookupItem<long>>> FetchRolesAsync()
        {
            var roles = await _dbContext.Set<Role>().AsNoTracking().Select(role => new LookupItem<long>
            {
                Text = role.Name,
                Value = role.Id
            }).ToListAsync();

            return roles.AsReadOnly();
        }
    }
}