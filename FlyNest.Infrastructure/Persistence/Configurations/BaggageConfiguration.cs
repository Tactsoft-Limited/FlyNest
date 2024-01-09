using FlyNest.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlyNest.Infrastructure.Persistence.Configurations;

public class BaggageConfiguration:IEntityTypeConfiguration<Baggage>
{
    public void Configure(EntityTypeBuilder<Baggage> builder)
    {
        builder.ToTable(nameof(Baggage));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FlightClass).HasMaxLength(70);
        builder.HasOne(x => x.Flight).WithMany(x => x.Baggages).HasForeignKey(x => x.FlightId);
    }
}