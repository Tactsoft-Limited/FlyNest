using FlyNest.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlyNest.Infrastructure.Persistence.Configurations;

public class HotelImagesConfiguration:IEntityTypeConfiguration<HotelImages>
{
    public void Configure(EntityTypeBuilder<HotelImages> builder)
    {
        builder.ToTable(nameof(HotelImages));
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Hotel).WithMany(x => x.HotelImages).HasForeignKey(x => x.HotelId);
    }
}