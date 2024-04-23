using FlyNest.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlyNest.Infrastructure.Persistence.Configurations;

public class VisaRequestConfiguration : IEntityTypeConfiguration<VisaRequest>
{
    public void Configure(EntityTypeBuilder<VisaRequest> builder)
    {
        builder.ToTable(nameof(VisaRequest));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CountryName).HasMaxLength(120);
        builder.Property(x => x.FirstName).HasMaxLength(85);
        builder.Property(x => x.LastName).HasMaxLength(85);
        builder.Property(x => x.Email).HasMaxLength(85);
        builder.Property(x => x.MobileNumber).HasMaxLength(20);
        builder.Property(x => x.Requirements).HasMaxLength(500);

        builder.HasData(
            new VisaRequest { Id = 1, CountryName = "Dummy Country 1", FirstName = "John", LastName = "Doe", Email = "john@example.com", MobileNumber = "1234567890", Requirements = "Dummy requirement 1" },
            new VisaRequest { Id = 2, CountryName = "Dummy Country 2", FirstName = "Jane", LastName = "Doe", Email = "jane@example.com", MobileNumber = "9876543210", Requirements = "Dummy requirement 2" },
            new VisaRequest { Id = 3, CountryName = "Dummy Country 3", FirstName = "Alice", LastName = "Smith", Email = "alice@example.com", MobileNumber = "5555555555", Requirements = "Dummy requirement 3" },
            new VisaRequest { Id = 4, CountryName = "Dummy Country 4", FirstName = "Bob", LastName = "Johnson", Email = "bob@example.com", MobileNumber = "9999999999", Requirements = "Dummy requirement 4" },
            new VisaRequest { Id = 5, CountryName = "Dummy Country 5", FirstName = "Eve", LastName = "Taylor", Email = "eve@example.com", MobileNumber = "1111111111", Requirements = "Dummy requirement 5" }
        );
    }
}
