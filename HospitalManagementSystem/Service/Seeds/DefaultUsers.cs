using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Service.Constants;
using System.Security.Claims;

namespace Service.Seeds
{
    public static class DefaultUsers
    {
        public static async Task SeedSuperAdminAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var defaultUser = new User
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
            await roleManager.AddPermissionClaim(adminRole, "patients");
            await roleManager.AddPermissionClaim(adminRole, "doctors");
            await roleManager.AddPermissionClaim(adminRole, "nurses");
            await roleManager.AddPermissionClaim(adminRole, "receptionists");
            await roleManager.AddPermissionClaim(adminRole, "operations");
            await roleManager.AddPermissionClaim(adminRole, "beds");
            await roleManager.AddPermissionClaim(adminRole, "tests");
            await roleManager.AddPermissionClaim(adminRole, "bills");
            await roleManager.AddPermissionClaim(adminRole, "payments"); 
        }

        public static async Task AddPermissionClaim(this RoleManager<IdentityRole> roleManager, IdentityRole role, string module)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = PolicyTypes.GeneratePermissionsForModule(module);
            foreach (var permission in allPermissions)
            {
                if (!allClaims.Any(a => a.Type == CustomClaimTypes.Permission && a.Value == permission))
                {
                    await roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, permission));
                }
            }
        }
    }
}