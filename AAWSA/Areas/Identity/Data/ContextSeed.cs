using AAWSA.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAWSA.Areas.Identity.Data
{
    public static class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<AAWSAUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Role.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Role.Branch_Operator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Role.Head_Office_Operator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Role.Technician.ToString()));
            
        }

        public static async Task SeedAdminAsync(UserManager<AAWSAUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new AAWSAUser
            {
                UserName = "admin",
                Email = "admin@gmail.com",
                FirstName = "Natnael",
                LastName = "Fekadu",
                PhoneNumber="0942009596",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word.");
                    await userManager.AddToRoleAsync(defaultUser,Role.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Role.Branch_Operator.ToString());
                    await userManager.AddToRoleAsync(defaultUser,Role.Head_Office_Operator.ToString());
                    await userManager.AddToRoleAsync(defaultUser,Role.Technician.ToString());
                }

            }
        }
    }
}
