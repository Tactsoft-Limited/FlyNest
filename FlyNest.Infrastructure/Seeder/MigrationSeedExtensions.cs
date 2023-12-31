using FlyNest.SharedKernel.Core.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;
using static FlyNest.SharedKernel.Entities.Identities.IdentityModel;

namespace FlyNest.Infrastructure.Seeder;

public static class MigrationSeedExtensions
{
    public static IHost MigrateAndSeed(this IHost host)
    {
        SeedDatabaseAsync(host.Services).GetAwaiter().GetResult();
        return host;
    }

    public static async Task SeedDatabaseAsync(IServiceProvider services)
    {
        var scope = services.CreateScope();
        try
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
            await SeedDefaultUserRolesAsync(userManager, roleManager, PermissionHelper.GetAllPermissions());
        } catch(Exception ex)
        {
            Console.WriteLine($"{ex.Message}. {ex.Source}");
            throw;
        }
    }

    public static async Task SeedDefaultUserRolesAsync(
        UserManager<User> userManager,
        RoleManager<Role> roleManager,
        List<Claim> permissions)
    {
        var defaultRoles = DefaultApplicationRoles.GetDefaultRoles();
        if(!await roleManager.Roles.AnyAsync())
        {
            foreach(var defaultRole in defaultRoles)
            {
                await roleManager.CreateAsync(defaultRole);
            }
        }
        if(!await roleManager.RoleExistsAsync(DefaultApplicationRoles.SuperAdmin))
        {
            await roleManager.CreateAsync(new Role(DefaultApplicationRoles.SuperAdmin));
        }
        var defaultUser = DefaultApplicationUsers.GetSuperUser();
        var userByName = await userManager.FindByNameAsync(defaultUser.UserName);
        var userByEmail = await userManager.FindByEmailAsync(defaultUser.Email);
        if(userByName == null && userByEmail == null)
        {
            await userManager.CreateAsync(defaultUser, "P@ssword1");
            await userManager.UpdateSecurityStampAsync(defaultUser);
            foreach(var defaultRole in defaultRoles)
            {
                await userManager.AddToRoleAsync(defaultUser, defaultRole.Name);
            }
        }
        var role = await roleManager.FindByNameAsync(DefaultApplicationRoles.SuperAdmin);
        var rolePermissions = await roleManager.GetClaimsAsync(role);
        var allPermissions = permissions;
        foreach(var permission in allPermissions)
        {
            if(rolePermissions.Any(x => x.Value == permission.Value && x.Type == permission.Type) == false)
            {
                await roleManager.AddClaimAsync(role, permission);
            }
        }
    }
}