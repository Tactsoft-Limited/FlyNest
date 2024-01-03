using FlyNest.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlyNest.Infrastructure.Persistence.Configurations;

public class StoppiesConfiguration : IEntityTypeConfiguration<Stoppies>
{
    public void Configure(EntityTypeBuilder<Stoppies> builder)
    {
        builder.ToTable(nameof(Stoppies));
        builder.HasKey(x => x.Id);
        builder.HasOne(x=>x.Airport).WithMany(x=>x.Stoppies).HasForeignKey(x=>x.AirportId);
    }
}
