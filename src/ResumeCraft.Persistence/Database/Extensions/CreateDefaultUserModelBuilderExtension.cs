using Microsoft.EntityFrameworkCore;
using ResumeCraft.Domain.Entities.EnumCollections;
using ResumeCraft.Persistence.Features.Account.Membership;

namespace ResumeCraft.Persistence.Database.Extensions
{
    internal static class CreateDefaultUserModelBuilderExtension
    {
        internal static ModelBuilder CreateDefaultUsers(this ModelBuilder modelBuilder)
        {
            var adminRoleId = Guid.NewGuid();
            var userRoleId = Guid.NewGuid();
            var adminUserId = Guid.NewGuid();
            var userId = Guid.NewGuid();

            var adminUser = new ApplicationUser
            {
                Id = adminUserId,
                FirstName = "Reume",
                LastName = "Craft",
                Gender = Gender.Male,
                DateOfBirth = DateTime.Now,
                ImageUrl = null,
                UserName = "admin@resumecraft.com",
                NormalizedUserName = "ADMIN@RESUMECRAFT.COM",
                Email = "admin@resumecraft.com",
                NormalizedEmail = "ADMIN@RESUMECRAFT.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAECwQxcEyU6f4iIjDf7zbzFu+2ZyHBM6zI2o8ij4u9TH03SpFkG7aB2mkh80dPWVY1A==", //!@#123asdASD
                SecurityStamp = "PX7TSKXHPFXLAQXAWMMKTJRX4UJZR64A",
                LockoutEnabled = true,
            };
            var user = new ApplicationUser
            {
                Id = userId,
                FirstName = "Guest",
                LastName = "User",
                Gender = Gender.Male,
                DateOfBirth = DateTime.Now,
                ImageUrl = null,
                UserName = "user@resumecraft.com",
                NormalizedUserName = "USER@RESUMECRAFT.COM",
                Email = "user@resumecraft.com",
                NormalizedEmail = "USER@RESUMECRAFT.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAECwQxcEyU6f4iIjDf7zbzFu+2ZyHBM6zI2o8ij4u9TH03SpFkG7aB2mkh80dPWVY1A==", //!@#123asdASD
                SecurityStamp = "PX7TSKXHPFXLAQXAWMMKTJRX4UJZR64A",
                LockoutEnabled = true,
            };

            var adminRole = new ApplicationRole
            {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            };
            var userRole = new ApplicationRole
            {
                Id = userRoleId,
                Name = "User",
                NormalizedName = "USER"
            };

            var adminRoleAssign = new ApplicationUserRole { RoleId = adminRoleId, UserId = adminUserId };
            var userRoleAssign = new ApplicationUserRole { RoleId = userRoleId, UserId = userId };

            var adminUserClaim1 = new ApplicationUserClaim
            {
                Id = 1,
                UserId = adminUserId,
                ClaimValue = "admin@resumecraft.com",
                ClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"
            };
            var adminUserClaim2 = new ApplicationUserClaim
            {
                Id = 2,
                UserId = adminUserId,
                ClaimValue = "Admin",
                ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
            };
            var userClaim1 = new ApplicationUserClaim
            {
                Id = 3,
                UserId = userId,
                ClaimValue = "user@resumecraft.com",
                ClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"
            };
            var userClaim2 = new ApplicationUserClaim
            {
                Id = 4,
                UserId = userId,
                ClaimValue = "User",
                ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
            };

            modelBuilder.Entity<ApplicationRole>().HasData(adminRole, userRole);
            modelBuilder.Entity<ApplicationUser>().HasData(adminUser, user);
            modelBuilder.Entity<ApplicationUserRole>().HasData(adminRoleAssign, userRoleAssign);
            modelBuilder.Entity<ApplicationUserClaim>().HasData(adminUserClaim1, adminUserClaim2, userClaim1, userClaim2);

            return modelBuilder;
        }
    }
}
