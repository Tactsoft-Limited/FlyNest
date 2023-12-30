using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static FlyNest.SharedKernel.Entities.Identities.IdentityModel;

namespace FlyNest.Infrastructure.Persistence.Configurations.IdentityModelConfiguration;

public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
{
    public void Configure(EntityTypeBuilder<UserClaim> builder)
    {
        builder.ToTable(nameof(UserClaim));
        builder.HasKey(x => x.Id);
    }
}
