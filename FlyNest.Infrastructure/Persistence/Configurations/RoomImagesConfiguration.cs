using FlyNest.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlyNest.Infrastructure.Persistence.Configurations;

public class RoomImagesConfiguration:IEntityTypeConfiguration<RoomImages>
{
    public void Configure(EntityTypeBuilder<RoomImages> builder)
    {
        builder.ToTable(nameof(RoomImages));
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Room).WithMany(x => x.RoomImages).HasForeignKey(x => x.RoomId);
    }
}