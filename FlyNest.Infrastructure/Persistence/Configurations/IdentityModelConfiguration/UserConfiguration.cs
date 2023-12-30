using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static FlyNest.SharedKernel.Entities.Identities.IdentityModel;

namespace FlyNest.Infrastructure.Persistence.Configurations.IdentityModelConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Email).HasMaxLength(85);
        builder.Property(x => x.UserName).HasMaxLength(85);
        builder.Property(x => x.NormalizedEmail).HasMaxLength(85);
        builder.Property(x => x.NormalizedUserName).HasMaxLength(85);
    }
}
