namespace FlyNest.Application.ViewModels.Account;

public class VmUserRoles
{
    public string RoleName { get; set; }

    public bool Selected { get; set; }
}

public class VmManageUserRoles
{
    public string UserId { get; set; }

    public IList<VmUserRoles> UserRoles { get; set; }
}

