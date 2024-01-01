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
        builder.Property(x => x.AirlineName).HasMaxLength(250).IsRequired(true);
        builder.Property(x => x.ContactInfo).HasMaxLength(250).IsRequired(true);
        builder.Property(x => x.Website).HasMaxLength(250).IsRequired(true);
        
    }
}
