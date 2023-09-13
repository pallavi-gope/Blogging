using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blogging.Web.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //seed roles (User, Admin, SuperAdmin)
            var adminRoleId = "cdf9ca4a-b7e0-49c4-ab46-f40f4ad6c919";
            var superAdminRoleId = "b3f5449a-2660-46a1-9c75-b940a5aedacf";
            var userRoleId = "c73c6d27-da14-4bd8-8a67-a55e46cc3df3";
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId
                },
                new IdentityRole
                {
                    Name = "SuperAdmin",
                    NormalizedName = "SuperAdmin",
                    Id = superAdminRoleId,
                    ConcurrencyStamp = superAdminRoleId
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "User",
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);

            //seed SuperAdminUser
            var superAdminId = "b3f5449a-2660-46a1-9c75-b940a5aedacf";
            var superAdminUser = new IdentityUser
            {
                UserName = "superadmin@blogger.com",
                Email = "superadmin@blogger.com",
                NormalizedEmail = "superadmin@blogger.com".ToUpper(),
                NormalizedUserName = "superadmin@blogger.com".ToUpper(),
                Id = superAdminId
            };
            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(superAdminUser, "Superadmin@123");
            builder.Entity<IdentityUser>().HasData(superAdminUser);

            //Add all roles to SuperAdminUser
            var superAdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>{
                    RoleId = adminRoleId,
                    UserId = superAdminId,
                },
                new IdentityUserRole<string>{
                    RoleId = superAdminRoleId,
                    UserId = superAdminId,
                },
                new IdentityUserRole<string>{
                    RoleId = userRoleId,
                    UserId = superAdminId,
                }
            };
            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);
        }
    }
}
