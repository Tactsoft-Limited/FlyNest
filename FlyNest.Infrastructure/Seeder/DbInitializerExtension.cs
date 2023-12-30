using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using static FlyNest.SharedKernel.Entities.Identities.IdentityModel;

namespace FlyNest.Infrastructure.Seeder;

public static class DbInitializerExtension
{
    public static async Task<IApplicationBuilder> UseItToSeedSqlServerAsync(this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app, nameof(app));

        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        try
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<Role>>();
            await DbInitializer.SeedRoleAsync(userManager, roleManager);
            await DbInitializer.SeedBasicUserAsync(userManager, roleManager);
            await DbInitializer.SeedSuperAdminAsync(userManager, roleManager);
        } catch(Exception ex)
        {
            Console.WriteLine($"Error seeding basic user: {ex.Message}");
            throw;
        }

        return app;
    }
}
