namespace FlyNest.Application.ViewModels.RolePermission;

public class VmManageUserRoles
{
    public string UserId { get; set; }

    public IList<VmUserRoles> UserRoles { get; set; }
}

public class VmUserRoles
{
    public string RoleName { get; set; }

    public bool Selected { get; set; }
}