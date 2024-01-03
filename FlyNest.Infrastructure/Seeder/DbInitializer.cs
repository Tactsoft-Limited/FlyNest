using FlyNest.SharedKernel.Core.Constants;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using static FlyNest.SharedKernel.Entities.Identities.IdentityModel;

namespace FlyNest.Infrastructure.Seeder;

public static class DbInitializer
{
    public static async Task SeedRoleAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
    {
        await roleManager.CreateAsync(new Role(Roles.SuperAdmin.ToString()));
        await roleManager.CreateAsync(new Role(Roles.Admin.ToString()));
        await roleManager.CreateAsync(new Role(Roles.Basic.ToString()));
    }

    public static async Task SeedBasicUserAsync(UserManager<User> userManager)
    {
        var defaultUser = new User
        {
            UserName = "user@localhost.com",
            Email = "user@localhost.com",
            EmailConfirmed = true
        };
        if(userManager.Users.All(u => u.Id != defaultUser.Id))
        {
            var user = await userManager.FindByEmailAsync(defaultUser.Email);

            if(user == null)
            {
                await userManager.CreateAsync(defaultUser, "P@ssword1");
                await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
            }
        }
    }

    public static async Task SeedSuperAdminAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
    {
        var defaultUser = new User
        {
            UserName = "superadmin@localhost.com",
            Email = "superadmin@localhost.com",
            EmailConfirmed = true
        };
        if(userManager.Users.All(u => u.Id != defaultUser.Id))
        {
            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if(user == null)
            {
                await userManager.CreateAsync(defaultUser, "P@ssword1");
                await userManager.AddToRoleAsync(defaultUser, Roles.SuperAdmin.ToString());
            }
            await roleManager.SeedClaimsForSuperAdmin();
        }
    }

    private async static Task SeedClaimsForSuperAdmin(this RoleManager<Role> roleManager)
    {
        var adminRole = await roleManager.FindByNameAsync("SuperAdmin");
        await roleManager.AddPermissionClaim(adminRole, "Products");
    }

    public static async Task AddPermissionClaim(this RoleManager<Role> roleManager, Role role, string module)
    {
        var allClaims = await roleManager.GetClaimsAsync(role);
        var allPermissions = Permissions.GeneratePermissionsForModule(module);
        foreach(var permission in allPermissions)
        {
            if(!allClaims.Any(a => a.Type == "Permission" && a.Value == permission))
            {
                await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
            }
        }
    }
}
