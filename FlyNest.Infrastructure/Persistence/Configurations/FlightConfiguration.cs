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
        builder.HasOne(x => x.Airline).WithMany(x => x.Flights).HasForeignKey(x => x.AirlineId);
        builder.HasOne(x => x.DepatureFlight).WithMany(x => x.DepatureAirport).HasForeignKey(x => x.DepatureAirportId);
        builder.HasOne(x => x.ArrivalFlight).WithMany(x => x.ArrivalAirport).HasForeignKey(x => x.ArrivalAirportId);
        builder.Property(x => x.FlightNo).HasMaxLength(20);
        builder.Property(x => x.AircraftType).HasMaxLength(50);
        builder.Property(x => x.FlightDuration).HasMaxLength(30);
        builder.Property(x => x.FlightType).HasMaxLength(30);
        builder.HasData(
            new Flight
            {
                Id = 1,
                FlightNo = "BG433",
                AirlineId = 1,
                DepatureAirportId = 1,
                DepatureDate = new DateOnly(2024, 01, 01),
                DepatureTime = new TimeOnly(11, 0),
                ArrivalAirportId = 7,
                ArrivalDate = new DateOnly(2024, 01, 01),
                ArrivalTime = new TimeOnly(14, 0),
                Price = 5600,
                AircraftType = "B 787-8 Dreamliner",
                FlightDuration = new TimeSpan(3, 0, 0),
                FlightType = "Non-Stop",
                CreatedBy = 1,
                CreatedDate = DateTimeOffset.Now,
            },
            new Flight
            {
                Id = 2,
                FlightNo = "BS141",
                AirlineId = 2,
                DepatureAirportId = 1,
                DepatureDate = new DateOnly(2024, 01, 01),
                DepatureTime = new TimeOnly(11, 0),
                ArrivalAirportId = 7,
                ArrivalDate = new DateOnly(2024, 01, 01),
                ArrivalTime = new TimeOnly(14, 0),
                Price = 5600,
                AircraftType = "B 787-8 Dreamliner",
                FlightDuration = new TimeSpan(3, 0, 0),
                FlightType = "Non-Stop",
                CreatedBy = 1,
                CreatedDate = DateTimeOffset.Now,
            },
            new Flight
            {
                Id = 3,
                FlightNo = "VQ927",
                AirlineId = 3,
                DepatureAirportId = 1,
                DepatureDate = new DateOnly(2024, 01, 01),
                DepatureTime = new TimeOnly(11, 0),
                ArrivalAirportId = 7,
                ArrivalDate = new DateOnly(2024, 01, 01),
                ArrivalTime = new TimeOnly(13, 30),
                Price = 5600,
                AircraftType = "B 787-8 Dreamliner",
                FlightDuration = new TimeSpan(2, 30, 0),
                FlightType = "Non-Stop",
                CreatedBy = 1,
                CreatedDate = DateTimeOffset.Now,
            },
            new Flight
            {
                Id = 4,
                FlightNo = "VQ729",
                AirlineId = 3,
                DepatureAirportId = 7,
                DepatureDate = new DateOnly(2024, 01, 05),
                DepatureTime = new TimeOnly(16, 30),
                ArrivalAirportId = 1,
                ArrivalDate = new DateOnly(2024, 01, 01),
                ArrivalTime = new TimeOnly(19, 0),
                Price = 5600,
                AircraftType = "B 787-8 Dreamliner",
                FlightDuration = new TimeSpan(2, 30, 0),
                FlightType = "Non-Stop",
                CreatedBy = 1,
                CreatedDate = DateTimeOffset.Now,
            },
            new Flight
            {
                Id = 5,
                FlightNo = "BS241",
                AirlineId = 2,
                DepatureAirportId = 7,
                DepatureDate = new DateOnly(2024, 01, 05),
                DepatureTime = new TimeOnly(16, 30),
                ArrivalAirportId = 1,
                ArrivalDate = new DateOnly(2024, 01, 01),
                ArrivalTime = new TimeOnly(19, 0),
                Price = 5600,
                AircraftType = "B 787-8 Dreamliner",
                FlightDuration = new TimeSpan(3, 0, 0),
                FlightType = "Non-Stop",
                CreatedBy = 1,
                CreatedDate = DateTimeOffset.Now,
            },
            new Flight
            {
                Id = 6,
                FlightNo = "BG333",
                AirlineId = 1,
                DepatureAirportId = 7,
                DepatureDate = new DateOnly(2024, 01, 05),
                DepatureTime = new TimeOnly(16, 30),
                ArrivalAirportId = 1,
                ArrivalDate = new DateOnly(2024, 01, 01),
                ArrivalTime = new TimeOnly(19, 0),
                Price = 5600,
                AircraftType = "B 787-8 Dreamliner",
                FlightDuration = new TimeSpan(3, 0, 0),
                FlightType = "Non-Stop",
                CreatedBy = 1,
                CreatedDate = DateTimeOffset.Now,
            });
    }
}
