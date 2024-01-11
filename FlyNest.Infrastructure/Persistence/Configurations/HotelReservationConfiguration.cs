using FlyNest.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlyNest.Infrastructure.Persistence.Configurations;

public class HotelReservationConfiguration : IEntityTypeConfiguration<HotelReservation>
{
    public void Configure(EntityTypeBuilder<HotelReservation> builder)
    {
        builder.ToTable(nameof(HotelReservation));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CityName).HasMaxLength(85);
        builder.Property(x => x.PreferenceHotel).HasMaxLength(85);
        builder.Property(x => x.ClientName).HasMaxLength(85);
        builder.Property(x => x.EmailAddress).HasMaxLength(50);
        builder.Property(x => x.ContactNumber).HasMaxLength(20);
        builder.Property(x => x.AlternativeContact).HasMaxLength(20);
    }
}
