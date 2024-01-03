using FlyNest.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlyNest.Infrastructure.Persistence.Configurations;

public class FlightConfiguration : IEntityTypeConfiguration<Flight>
{
    public void Configure(EntityTypeBuilder<Flight> builder)
    {
        builder.ToTable(nameof(Flight));
        builder.HasKey(x => x.Id);
        builder.HasOne(x=>x.Airline).WithMany(x=>x.Flights).HasForeignKey(x=>x.AirlineId);
        builder.HasOne(x => x.Stoppies).WithMany(x => x.Flights).HasForeignKey(x => x.StoppieId);
    }
}
