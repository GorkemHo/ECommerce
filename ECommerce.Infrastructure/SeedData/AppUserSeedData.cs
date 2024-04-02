using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.SeedData
{
    public static class AppUserSeedData
    {
        public static void SeedUsers(this UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                var roles = new List<IdentityRole>
                {
                    new IdentityRole { Name = "Admin" },
                    new IdentityRole { Name = "User" }
                };

                foreach (var role in roles)
                {
                    roleManager.CreateAsync(role).GetAwaiter().GetResult();
                }
            }

            if (userManager.FindByEmailAsync("admin@example.com").GetAwaiter().GetResult() == null)
            {
                var adminUser = new AppUser
                {
                    FirstName = "Admin",
                    LastName = "User",
                    UserName = "admin@example.com",
                    Email = "admin@example.com",
                    Address = "Admin Address",
                    CreateDate = DateTime.Now,
                    Status = Status.Active
                };

                userManager.CreateAsync(adminUser, "Admin123").GetAwaiter().GetResult();
                userManager.AddToRoleAsync(adminUser, "Admin").GetAwaiter().GetResult();
            }

            if (userManager.FindByEmailAsync("user@example.com").GetAwaiter().GetResult() == null)
            {
                var regularUser = new AppUser
                {
                    FirstName = "Regular",
                    LastName = "User",
                    UserName = "user@example.com",
                    Email = "user@example.com",
                    Address = "User Address",
                    CreateDate = DateTime.Now,
                    Status = Status.Active
                };

                userManager.CreateAsync(regularUser, "User123").GetAwaiter().GetResult();
                userManager.AddToRoleAsync(regularUser, "User").GetAwaiter().GetResult();
            }

        }
    }
}
