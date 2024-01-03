using FlyNest.Infrastructure.Interfaces.Helpers;
using FlyNest.SharedKernel.Entities.Audit;
using FlyNest.SharedKernel.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;

namespace FlyNest.Infrastructure.Persistence.Interceptors;

public class AuditableEntitySaveChangesInterceptor(IUserResolverService userResolverService) : SaveChangesInterceptor
{
    private readonly IUserResolverService _userResolverService = userResolverService;

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        if(_userResolverService.IsUserAuthorized())
        {
            EntitySaveChanges(eventData.Context);
            AuditTrail(eventData.Context);
            Validate(eventData.Context);
        }
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        if(_userResolverService.IsUserAuthorized())
        {
            EntitySaveChanges(eventData.Context);
            AuditTrail(eventData.Context);
            Validate(eventData.Context);
        }
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void EntitySaveChanges(DbContext context)
    {
        if(context == null)
            return;

        var now = DateTimeOffset.UtcNow;
        var userId = _userResolverService.CurentUserId;

        var entries = context.ChangeTracker
            .Entries<AuditableEntity>()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
        foreach(var entry in entries)
        {
            if(entry.Entity is AuditableEntity trackable)
            {
                switch(entry.State)
                {
                    case EntityState.Modified:

                        trackable.ModifiedDate = now;
                        trackable.ModifiedBy = userId;
                        trackable.UpdateNo = context.Entry(trackable).Property(x => x.UpdateNo).OriginalValue + 1;
                        context.Entry(trackable).Property(x => x.CreatedDate).IsModified = false;
                        context.Entry(trackable).Property(x => x.CreatedBy).IsModified = false;
                        break;

                    case EntityState.Added:
                        trackable.CreatedDate = now;
                        trackable.CreatedBy = userId;
                        trackable.ModifiedDate = now;
                        trackable.ModifiedBy = userId;
                        break;
                }
            }
        }
    }

    private void AuditTrail(DbContext context)
    {
        if(context == null)
            return;

        long userId = _userResolverService.CurentUserId;

        context.ChangeTracker.DetectChanges();

        var auditEntries = new List<AuditEntry>();
        foreach(var entry in context.ChangeTracker.Entries())
        {
            if(entry.Entity is BaseEntity ||
                entry.Entity is AuditLog ||
                entry.State == EntityState.Detached ||
                entry.State == EntityState.Unchanged)
                continue;

            var auditEntry = new AuditEntry(entry) { TableName = entry.Entity.GetType().Name, UserId = userId };
            auditEntries.Add(auditEntry);
            foreach(var property in entry.Properties)
            {
                string propertyName = property.Metadata.Name;
                if(property.Metadata.IsPrimaryKey())
                {
                    auditEntry.KeyValues[propertyName] = property.CurrentValue;
                    continue;
                }
                switch(entry.State)
                {
                    case EntityState.Added:
                        auditEntry.AuditType = AuditType.Create;
                        auditEntry.NewValues[propertyName] = property.CurrentValue;
                        break;
                    case EntityState.Deleted:
                        auditEntry.AuditType = AuditType.Delete;
                        auditEntry.OldValues[propertyName] = property.OriginalValue;
                        break;
                    case EntityState.Modified:
                        if(property.IsModified)
                        {
                            auditEntry.ChangedColumns.Add(propertyName);
                            auditEntry.AuditType = AuditType.Update;
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                        }
                        break;
                }
            }
        }
        foreach(var auditEntry in auditEntries)
        {
            context.AddAsync(auditEntry.ToAuditLog());
        }
    }

    private static void Validate(DbContext context)
    {
        var serviceProvider = context.GetInfrastructure().GetService<IServiceProvider>();
        var items = new Dictionary<object, object>();

        foreach(var result in from entry in context.ChangeTracker.Entries()
            where entry.State == EntityState.Added || entry.State == EntityState.Modified
            let entity = entry.Entity
            let validationContext = new ValidationContext(entity, serviceProvider, items)
            let results = new List<ValidationResult>()
            where Validator.TryValidateObject(entity, validationContext, results, true) == false
            from result in results
            where result != ValidationResult.Success
            select result)
        {
            throw new ValidationException(result.ErrorMessage);
        }
    }
}