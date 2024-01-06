using FlyNest.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlyNest.Infrastructure.Persistence.Configurations;

public class RoomConfiguration:IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.ToTable(nameof(Room));
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Hotel).WithMany(x => x.Rooms).HasForeignKey(x => x.HotelId);
        builder.Property(x => x.Name).HasMaxLength(70);
        builder.Property(x => x.Facilities).HasMaxLength(250);
        builder.Property(x => x.Benefits).HasMaxLength(250);
    }
}