using Microsoft.AspNetCore.Authorization;

namespace FlyNest.SharedKernel.Core.Permission;

public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    public PermissionAuthorizationHandler()
    {
    }

    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PermissionRequirement requirement)
    {
        if(context.User == null)
        {
            return;
        }

        var permissions = await Task.Run(
            () => context.User.Claims
                .Where(
                    x => x.Type == "Permission" && x.Value == requirement.Permission && x.Issuer == "LOCAL AUTHORITY")
                .ToList());

        if(permissions.Count != 0)
        {
            context.Succeed(requirement);
        }
    }
}