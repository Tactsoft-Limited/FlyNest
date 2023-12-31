using FluentValidation;
using FlyNest.Application.Repositories.Helpers;
using FlyNest.Infrastructure.Interfaces.BaseRepo;
using FlyNest.Infrastructure.Interfaces.Helpers;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlyNest.Application;

public static class ServiceCollectionExtension
{
    public static IServiceCollection ApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);

        services.Scan(
            scan => scan.FromAssemblyOf<IApplication>()
                .AddClasses(classes => classes.AssignableTo<IApplication>())
                .AddClasses(classes => classes.AssignableTo(typeof(IBaseRepository<>)))
                .AsSelfWithInterfaces()
                .WithScopedLifetime());

        services.AddScoped<IUserResolverService, UserResolverService>();
        services.AddScoped<IEmailSender, EmailSender>();

        services.AddValidatorsFromAssembly(typeof(IApplication).Assembly);
        services.AddAutoMapper(x => x.AddMaps(typeof(IApplication).Assembly));

        return services;
    }
}
