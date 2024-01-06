using FlyNest.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlyNest.Infrastructure.Persistence.Configurations;

public class StopoverConfiguration : IEntityTypeConfiguration<Stopover>
{
    public void Configure(EntityTypeBuilder<Stopover> builder)
    {
        builder.ToTable(nameof(Stopover));
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.StopoverAirport).WithMany(x => x.Stopovers).HasForeignKey(x => x.AirportId);
        builder.HasOne(x => x.Flight).WithMany(x => x.Stopovers).HasForeignKey(x => x.FlightId);
    }
}
