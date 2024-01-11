using FlyNest.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlyNest.Infrastructure.Persistence.Configurations;

public class FlightReservationConfiguration : IEntityTypeConfiguration<FlightReservation>
{
    public void Configure(EntityTypeBuilder<FlightReservation> builder)
    {
        builder.ToTable(nameof(FlightReservation));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FlightType).HasMaxLength(85);
        builder.Property(x => x.DepartureCity).HasMaxLength(85);
        builder.Property(x => x.ArrivalCity).HasMaxLength(85);
        builder.Property(x => x.FlightClass).HasMaxLength(30);
        builder.Property(x => x.ClientName).HasMaxLength(85);
        builder.Property(x => x.EmailAddress).HasMaxLength(85);
        builder.Property(x => x.ContactNumber).HasMaxLength(85);
        builder.Property(x => x.AlternativeContact).HasMaxLength(85);
        builder.Property(x => x.DepartureCity).HasMaxLength(85);
        builder.Property(x => x.DepartureCity).HasMaxLength(85);
        builder.Property(x => x.Status).HasMaxLength(35);
    }
}
