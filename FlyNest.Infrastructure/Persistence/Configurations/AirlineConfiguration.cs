using FlyNest.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlyNest.Infrastructure.Persistence.Configurations;

public class AirlineConfiguration : IEntityTypeConfiguration<Airline>
{
    public void Configure(EntityTypeBuilder<Airline> builder)
    {
        builder.ToTable(nameof(Airline));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.AirlineName).HasMaxLength(85);
        builder.Property(x => x.ContactInfo).HasMaxLength(150);
        builder.Property(x => x.Website).HasMaxLength(100);
        builder.HasData(
            new Airline
            {
                Id = 1,
                AirlineName = "Biman Bangladesh Airlines",
                ContactInfo = "Balaka Bhaban Kurmitola, Dhaka, Bangladesh",
                Website = "http://biman-airlines.com",
                CreatedBy = 1,
                CreatedDate = DateTimeOffset.Now,
            },
            new Airline
            {
                Id = 2,
                AirlineName = "US-Bangla Airlines",
                ContactInfo = "77 Sohrawardi Avenue, Baridhara Diplomatic Zone, Dhaka, Bangladesh",
                Website = "https://usbair.com",
                CreatedBy = 1,
                CreatedDate = DateTimeOffset.Now,
            },
            new Airline
            {
                Id = 3,
                AirlineName = "Novoair",
                ContactInfo = "House-50, Road-11, Block-F, Banani, Dhaka, Bangladesh",
                Website = "https://www.flynovoair.com",
                CreatedBy = 1,
                CreatedDate = DateTimeOffset.Now,
            },
            new Airline
            {
                Id = 4,
                AirlineName = "Regent Airways",
                ContactInfo = "Balaka Bhaban Kurmitola, Dhaka, Bangladesh",
                Website = "http://biman-airlines.com",
                CreatedBy = 1,
                CreatedDate = DateTimeOffset.Now,
            });
    }
}
