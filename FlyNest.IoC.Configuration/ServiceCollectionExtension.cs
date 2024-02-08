using FlyNest.Application;
using FlyNest.Infrastructure;
using FlyNest.SharedKernel.Core.FileExtentions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlyNest.IoC.Configuration;

public static class ServiceCollectionExtension
{
    public static IServiceCollection ServiceRegistation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllersWithViews();
        // Add services to the container.

        services.InfrastructureServices(configuration);
        services.ApplicationServices(configuration);
        services.AddAuthorizationBuilder().AddPolicy("DebugPolicy", policy => policy.RequireAssertion(context => true));

        services.AddScoped<IFileStorageService, FileStorageService>();
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(
                options =>
                {
                    options.ExpireTimeSpan = TimeSpan.Zero; // Expire the cookie when the browser is closed
                    options.SlidingExpiration = false; // Disable sliding expiration
                });
        services.AddSession();

        return services;
    }
}
