using FlyNest.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlyNest.Infrastructure.Persistence.Configurations;

public class ImageSliderConfiguration : IEntityTypeConfiguration<ImageSlider>
{
    public void Configure(EntityTypeBuilder<ImageSlider> builder)
    {
        builder.ToTable(nameof(ImageSlider));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title).HasMaxLength(150);
        builder.Property(x => x.SubTitle).HasMaxLength(150);
    }
}
