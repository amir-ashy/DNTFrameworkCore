using DNTFrameworkCore.TestCqrsAPI.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DNTFrameworkCore.TestCqrsAPI.Infrastructure.Mappings.Identity
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(a => a.UserName).IsRequired().HasMaxLength(User.MaxUserNameLength);
            builder.Property(a => a.NormalizedUserName).IsRequired().HasMaxLength(User.MaxUserNameLength);
            builder.Property(a => a.PasswordHash).IsRequired().HasMaxLength(User.MaxPasswordHashLength);
            builder.Property(a => a.DisplayName).IsRequired().HasMaxLength(User.MaxDisplayNameLength);
            builder.Property(a => a.NormalizedDisplayName).IsRequired().HasMaxLength(User.MaxDisplayNameLength);
            builder.Property(a => a.SecurityStamp).IsRequired().HasMaxLength(User.MaxSecurityStampLength);

            builder.HasIndex(a => a.NormalizedUserName).HasDatabaseName("UIX_User_NormalizedUserName").IsUnique();
            builder.HasIndex(a => a.NormalizedDisplayName).HasDatabaseName("UIX_User_NormalizedDisplayName").IsUnique();

            builder.HasMany(a => a.Roles).WithOne(a => a.User).HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(a => a.Claims).WithOne(a => a.User).HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(a => a.Permissions).WithOne(a => a.User).HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(a => a.Tokens).WithOne(a => a.User).HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(nameof(User));
        }
    }
}