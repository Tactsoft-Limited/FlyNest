using FlyNest.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlyNest.Infrastructure.Persistence;

public class PolicyConfiguration:IEntityTypeConfiguration<Policy>
{
    public void Configure(EntityTypeBuilder<Policy> builder)
    {
        builder.ToTable(nameof(Policy));
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Flight).WithMany(x => x.Policies).HasForeignKey(x=>x.FlightId);
        
    }
}