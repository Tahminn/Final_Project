using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Service.Constants;
using System.Security.Claims;

namespace Service.Seeds
{
    public static class DefaultUsers
    {
        //public static async Task SeedBasicUserAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        //{
        //    //Seed Default User
        //    var defaultUser = new AppUser
        //    {
        //        UserName = "basicuser@gmail.com",
        //        Email = "basicuser@gmail.com",
        //        EmailConfirmed = true,
        //        PhoneNumberConfirmed = true,
        //    };
        //    if (userManager.Users.All(u => u.Id != defaultUser.Id))
        //    {
        //        var user = await userManager.FindByEmailAsync(defaultUser.Email);
        //        if (user == null)
        //        {
        //            await userManager.CreateAsync(defaultUser, "123Pa$$word!");
        //            await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
        //        }
        //    }
        //}

        public static async Task SeedSuperAdminAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new AppUser
            {
                UserName = "tahmin.fatiyev@gmail.com",
                Email = "tahmin.fatiyev@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Raveniu123.");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Member.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.SuperAdmin.ToString());
                }
                await roleManager.SeedClaimsForSuperAdmin();
            }
        }

        private async static Task SeedClaimsForSuperAdmin(this RoleManager<IdentityRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("SuperAdmin");
            await roleManager.AddPermissionClaim(adminRole, "Patients");
            await roleManager.AddPermissionClaim(adminRole, "Doctors");
            await roleManager.AddPermissionClaim(adminRole, "Nurses");
            await roleManager.AddPermissionClaim(adminRole, "Receptionist");
        }

        public static async Task AddPermissionClaim(this RoleManager<IdentityRole> roleManager, IdentityRole role, string module)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = Permissions.GeneratePermissionsForModule(module);
            foreach (var permission in allPermissions)
            {
                if (!allClaims.Any(a => a.Type == "Permission" && a.Value == permission))
                {
                    await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
                }
            }
        }
    }
}