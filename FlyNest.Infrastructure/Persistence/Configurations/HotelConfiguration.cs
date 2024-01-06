using FlyNest.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlyNest.Infrastructure.Persistence.Configurations;

public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder.ToTable(name: nameof(Hotel));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(80).IsRequired();
        builder.Property(x => x.Address).HasMaxLength(200).IsRequired();
        builder.Property(x => x.CountryName).HasMaxLength(80).IsRequired();
        builder.Property(x => x.CityName).HasMaxLength(70).IsRequired();
        builder.Property(x => x.LocationMap).HasMaxLength(150).IsRequired();
    }
}
