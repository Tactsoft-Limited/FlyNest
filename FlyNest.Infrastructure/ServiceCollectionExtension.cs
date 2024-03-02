using FlyNest.Infrastructure.Persistence;
using FlyNest.Infrastructure.Persistence.Interceptors;
using FlyNest.SharedKernel.Core.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using static FlyNest.SharedKernel.Entities.Identities.IdentityModel;

namespace FlyNest.Infrastructure;

public static class ServiceCollectionExtension
{
    public static IServiceCollection InfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(configuration);

        services.AddScoped<AuditableEntitySaveChangesInterceptor>();
        services.AddDbContext<FlyNestDbContext>((serviceProvider, builder) =>
        {
            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            builder.UseLoggerFactory(serviceProvider.GetRequiredService<ILoggerFactory>());
            builder.LogTo(Console.WriteLine, LogLevel.Debug);
        }, ServiceLifetime.Scoped);

        services.AddIdentity<User, Role>(o =>
        {
            o.Password.RequireDigit = false;
            o.Password.RequireLowercase = false;
            o.Password.RequireUppercase = false;
            o.Password.RequireNonAlphanumeric = false;
            o.User.RequireUniqueEmail = true;
            o.SignIn.RequireConfirmedEmail = true;

        }).AddEntityFrameworkStores<FlyNestDbContext>().AddDefaultTokenProviders();

        services.AddMvc(config => config.Filters.Add(new AuthorizeFilter()));

        services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
        services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();

        return services;
    }
}