using System;
using System.Linq;
using DNTFrameworkCore.EFCore.Context;
using DNTFrameworkCore.FluentValidation;
using DNTFrameworkCore.TestWebApp.Application.Identity.Models;
using DNTFrameworkCore.TestWebApp.Domain.Identity;
using DNTFrameworkCore.TestWebApp.Resources;
using FluentValidation;

namespace DNTFrameworkCore.TestWebApp.Application.Identity.Validators
{
    public class RoleValidator : FluentModelValidator<RoleModel>
    {
        private readonly IDbContext _dbContext;

        public RoleValidator(IDbContext dbContext, IMessageLocalizer localizer)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

            RuleFor(m => m.Name).NotEmpty()
                .WithMessage(localizer["Role.Fields.Name.Required"])
                .MinimumLength(3)
                .WithMessage(localizer["Role.Fields.Name.MinimumLength"])
                .MaximumLength(Role.MaxNameLength)
                .WithMessage(localizer["Role.Fields.Name.MaximumLength"])
                .DependentRules(() =>
                {
                    RuleFor(m => m).Must(model => IsUniqueName(model.Name, model.Id))
                        .WithMessage(localizer["Role.Fields.Name.Unique"])
                        .OverridePropertyName(nameof(Role.Name));
                });

            RuleFor(m => m.Description)
                .MaximumLength(Role.MaxDescriptionLength)
                .WithMessage(localizer["Role.Fields.Description.MaximumLength"]);
        }

        private bool IsUniqueName(string name, long id)
        {
            return !_dbContext.Set<Role>().Any(u => u.NormalizedName == Role.NormalizeName(name) && u.Id != id);
        }
    }
}