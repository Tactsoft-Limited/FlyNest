using FlyNest.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlyNest.Infrastructure.Persistence.Configurations;

public class ConfirmBookingConfiguration : IEntityTypeConfiguration<ConfirmBooking>
{
    public void Configure(EntityTypeBuilder<ConfirmBooking> builder)
    {
        builder.ToTable(nameof(ConfirmBooking));
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.TourPackage).WithMany(x => x.ConfirmBookings).HasForeignKey(x => x.TourPackageId);
        builder.Property(x => x.PackageTitle).HasMaxLength(150);
        builder.Property(x => x.TransactionId).HasMaxLength(85);
        builder.Property(x => x.ClientName).HasMaxLength(85);
        builder.Property(x => x.ClientEmail).HasMaxLength(85);
        builder.Property(x => x.ClientPhone).HasMaxLength(85);
    }
}
