using Microsoft.AspNetCore.Authorization;

namespace FlyNest.SharedKernel.Core.Permission;

public class PermissionRequirement(string permission) : IAuthorizationRequirement
{
    public string Permission { get; private set; } = permission;
}