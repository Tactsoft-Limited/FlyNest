using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FlyNest.Infrastructure.Extensions;

public static class ModelBuilderExtension
{
    public static void DateTimeConvention(this ModelBuilder modelBuilder)
    {
        foreach(var entity in modelBuilder.EntityTypes())
        {
            var dateTimeProperties = entity.GetProperties()
                .Where(
                    p => p.PropertyInfo.PropertyType == typeof(DateTime) ||
                        p.PropertyInfo.PropertyType == typeof(DateTimeOffset));

            foreach(var prop in dateTimeProperties)
            {
                // Use "datetime2" for DateTime properties and "datetimeoffset" for DateTimeOffset properties
                var columnType = prop.PropertyInfo.PropertyType == typeof(DateTime) ? "datetime2" : "datetimeoffset";

                modelBuilder.Entity(entity.Name).Property(prop.Name).HasColumnType(columnType);
            }
        }
    }


    public static void DecimalConvention(this ModelBuilder modelBuilder)
    {
        modelBuilder.EntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?))
            .ToList()
            .ForEach(
                p =>
                {
                    if(p.GetPrecision() is null)
                        p.SetPrecision(18);
                    if(p.GetScale() is null)
                        p.SetScale(4);
                });
    }

    public static void RelationConvetion(this ModelBuilder modelBuilder)
    {
        modelBuilder.EntityTypes()
            .SelectMany(e => e.GetForeignKeys())
            //.Where(e => !e.IsOwnership && e.DeleteBehavior == DeleteBehavior.Cascade)
            .ToList()
            .ForEach(relationship => relationship.DeleteBehavior = DeleteBehavior.Restrict);
    }

    public static void PluralizeTableNameConventions(this ModelBuilder modelBuilder, bool pluralize = true)
    {
        if(!pluralize)
        {
            foreach(var entity in modelBuilder.EntityTypes())
            {
                modelBuilder.Entity(entity.Name).ToTable(entity.DisplayName());
            }
        }
    }


    public static IEnumerable<IMutableEntityType> EntityTypes(this ModelBuilder builder)
    { return builder.Model.GetEntityTypes(); }
}
