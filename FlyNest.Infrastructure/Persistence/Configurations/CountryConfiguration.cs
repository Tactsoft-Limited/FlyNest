using FlyNest.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlyNest.Infrastructure.Persistence.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable(nameof(Country));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(85);
        builder.Property(x => x.CapitalCity).HasMaxLength(85);
        builder.Property(x => x.LocalTime).HasMaxLength(20);
        builder.Property(x => x.TelephoneCode).HasMaxLength(10);
        builder.Property(x => x.BankTime).HasMaxLength(85);
        builder.Property(x => x.EmbassyAddress).HasMaxLength(200);
        builder.Property(x => x.Language).HasMaxLength(100);
        builder.Property(x => x.Currency).HasMaxLength(85);
        builder.Property(x => x.TourismPlace).HasMaxLength(300);
        builder.Property(x => x.Image).HasMaxLength(50);
    }
}
