using Microsoft.EntityFrameworkCore;
using ResumeCraft.Persistence.Features.Account.Membership;

namespace ResumeCraft.Persistence.Database.Extensions
{
    internal static class IdentityModelBuilderExtension
    {
        internal static ModelBuilder ConfigureIdentityModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>(entity => entity.ToTable("Users"));
            modelBuilder.Entity<ApplicationUserClaim>(entity => entity.ToTable("UserClaims"));
            modelBuilder.Entity<ApplicationUserLogin>(entity => entity.ToTable("UserLogins"));
            modelBuilder.Entity<ApplicationUserToken>(entity => entity.ToTable("UserTokens"));

            modelBuilder.Entity<ApplicationRole>(entity => entity.ToTable("Roles"));
            modelBuilder.Entity<ApplicationRoleClaim>(entity => entity.ToTable("RoleClaims"));
            modelBuilder.Entity<ApplicationUserRole>(entity => entity.ToTable("UserRoles"));

            return modelBuilder;
        }
    }
}
