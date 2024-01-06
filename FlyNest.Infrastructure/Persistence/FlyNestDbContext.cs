using FlyNest.Infrastructure.Persistence.Configurations;
using FlyNest.Infrastructure.Persistence.Interceptors;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static FlyNest.SharedKernel.Entities.Identities.IdentityModel;

namespace FlyNest.Infrastructure.Persistence;

public class FlyNestDbContext(
    DbContextOptions<FlyNestDbContext> options,
    ILoggerFactory loggerFactory,
    AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) : IdentityDbContext<User, Role, long, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>(
    options)
{
    private readonly ILoggerFactory _loggerFactory = loggerFactory;
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    { return await base.SaveChangesAsync(cancellationToken); }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //base.OnConfiguring(optionsBuilder);
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
        optionsBuilder.UseLoggerFactory(_loggerFactory);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(IFlyNestContext).Assembly);
        builder.Model
            .GetEntityTypes()
            .SelectMany(x => x.GetForeignKeys())
            .ToList()
            .ForEach(x => x.DeleteBehavior = DeleteBehavior.Restrict);
        foreach(var property in builder.Model
            .GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
        {
            property.SetColumnType("decimal(18, 2)");
        }
    }
}
