using FlyNest.Application;
using FlyNest.Infrastructure;
using FlyNest.SharedKernel.Core.EmailService;
using FlyNest.SharedKernel.Core.FileExtentions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static FlyNest.SharedKernel.Core.PaymentGateway.SSLCommerzGateway;

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



        services.Configure<SSLCommerzSetting>(configuration.GetSection("SSLCommerzSetting"));
        services.Configure<MailSetting>(configuration.GetSection("MailSetting"));

        services.AddScoped<MailService, MailService>();
        services.AddScoped<IFileStorageService, FileStorageService>();
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
        {
            options.ExpireTimeSpan = TimeSpan.Zero;
            options.SlidingExpiration = false;
        });
        services.AddSession();

        return services;
    }
}
