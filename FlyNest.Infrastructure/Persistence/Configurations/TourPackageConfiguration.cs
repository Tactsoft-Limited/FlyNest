using FlyNest.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlyNest.Infrastructure.Persistence.Configurations;

public class TourPackageConfiguration : IEntityTypeConfiguration<TourPackage>
{
    public void Configure(EntityTypeBuilder<TourPackage> builder)
    {
        builder.ToTable(nameof(TourPackage));
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Country).WithMany(x => x.TourPackages).HasForeignKey(x => x.CountryId);
        builder.Property(x => x.Title).HasMaxLength(100);
        builder.Property(x => x.TourDescription).HasMaxLength(300);
    }
}
