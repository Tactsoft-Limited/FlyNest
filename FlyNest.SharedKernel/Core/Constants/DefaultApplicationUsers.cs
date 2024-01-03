using static FlyNest.SharedKernel.Entities.Identities.IdentityModel;

namespace FlyNest.SharedKernel.Core.Constants;

public class DefaultApplicationUsers
{
    public static User GetSuperUser()
    {
        var defaultUser = new User
        {
            UserName = "SuperAdmin",
            Email = "admin@localhost.com",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
        };
        return defaultUser;
    }
}