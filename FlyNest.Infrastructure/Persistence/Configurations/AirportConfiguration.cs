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
        builder.HasData(
            new Airport
            {
                Id = 1,
                Name = "Hazrat Shahjalal International Airport",
                Code = "DAC",
                CountryName = "Bangladesh",
                CityName = "Dhaka",
                CreatedBy = 1,
                CreatedDate = DateTimeOffset.Now,
            },
            new Airport
            {
                Id = 2,
                Name = "Shah Amanat International Airport",
                Code = "CGP",
                CountryName = "Bangladesh",
                CityName = "Chattogram",
                CreatedBy = 1,
                CreatedDate = DateTimeOffset.Now,
            },
            new Airport
            {
                Id = 3,
                Name = "Jashore Airport",
                Code = "JSR",
                CountryName = "Bangladesh",
                CityName = "Jashore",
                CreatedBy = 1,
                CreatedDate = DateTimeOffset.Now,
            },
            new Airport
            {
                Id = 4,
                Name = "Osmany International Airport",
                Code = "ZYL",
                CountryName = "Bangladesh",
                CityName = "Sylhet",
                CreatedBy = 1,
                CreatedDate = DateTimeOffset.Now,
            },
            new Airport
            {
                Id = 5,
                Name = "Comilla Airport",
                Code = "CLA",
                CountryName = "Bangladesh",
                CityName = "Comilla",
                CreatedBy = 1,
                CreatedDate = DateTimeOffset.Now,
            },
            new Airport
            {
                Id = 6,
                Name = "Ishurdi Airport",
                Code = "IRD",
                CountryName = "Bangladesh",
                CityName = "Ishurdi",
                CreatedBy = 1,
                CreatedDate = DateTimeOffset.Now,
            },
            new Airport
            {
                Id = 7,
                Name = "Cox's Bazar Airport",
                Code = "CXB",
                CountryName = "Bangladesh",
                CityName = "Cox's Bazar",
                CreatedBy = 1,
                CreatedDate = DateTimeOffset.Now,
            },
            new Airport
            {
                Id = 8,
                Name = "Saidpur Airport",
                Code = "SPD",
                CountryName = "Bangladesh",
                CityName = "Saidpur",
                CreatedBy = 1,
                CreatedDate = DateTimeOffset.Now,
            },
            new Airport
            {
                Id = 9,
                Name = "Shah Makhdum Airport",
                Code = "RJH",
                CountryName = "Bangladesh",
                CityName = "Rajshahi",
                CreatedBy = 1,
                CreatedDate = DateTimeOffset.Now,
            },
            new Airport
            {
                Id = 10,
                Name = "Barishal Airport",
                Code = "BZL",
                CountryName = "Bangladesh",
                CityName = "Barishal",
                CreatedBy = 1,
                CreatedDate = DateTimeOffset.Now,
            });
    }
}
