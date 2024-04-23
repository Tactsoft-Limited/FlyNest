using FlyNest.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlyNest.Infrastructure.Persistence.Configurations;

public class ImageGalleryConfiguration : IEntityTypeConfiguration<ImageGallery>
{
    public void Configure(EntityTypeBuilder<ImageGallery> builder)
    {
        builder.ToTable(nameof(ImageGallery));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.EventTitle).HasMaxLength(255);
        builder.Property(x => x.ImageUrl).HasMaxLength(100);
    }
}
