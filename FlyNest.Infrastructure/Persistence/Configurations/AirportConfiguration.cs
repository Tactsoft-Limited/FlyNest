using FlyNest.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlyNest.Infrastructure.Persistence.Configurations;

public class AirportConfiguration : IEntityTypeConfiguration<Airport>
{
    public void Configure(EntityTypeBuilder<Airport> builder)
    {
        builder.ToTable(nameof(Airport));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(85);
        builder.Property(x => x.Code).HasMaxLength(30);
        builder.Property(x => x.CountryName).HasMaxLength(85);
        builder.Property(x => x.CityName).HasMaxLength(85);
    }
}
