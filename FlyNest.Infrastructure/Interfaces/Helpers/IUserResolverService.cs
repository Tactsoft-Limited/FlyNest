using System.Security.Claims;

namespace FlyNest.Infrastructure.Interfaces.Helpers;

public interface IUserResolverService
{
    ClaimsPrincipal GetUser();

    long CurentUserId { get; }

    public bool IsUserAuthorized();
}
