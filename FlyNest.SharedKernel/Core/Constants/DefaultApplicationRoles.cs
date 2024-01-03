using System.Security.Claims;
using static FlyNest.SharedKernel.Entities.Identities.IdentityModel;

namespace FlyNest.SharedKernel.Core.Constants;

public static class DefaultApplicationRoles
{
    public const string SuperAdmin = "SuperAdmin";
    public const string Admin = "Admin";
    public const string Moderator = "Moderator";
    public const string Basic = "Basic";

    public static List<Role> GetDefaultRoles()
    {
        var roles = new List<Role> { new(SuperAdmin), new(Admin), new(Moderator), new(Basic) };
        return roles;
    }

    public static List<Claim> GetDefaultRoleClaims()
    {
        var roles = GetDefaultRoles();
        var claims = roles.Select(role => new Claim(ClaimTypes.Role, role.Name)).ToList();
        return claims;
    }
}

