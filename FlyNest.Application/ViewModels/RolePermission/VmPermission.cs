namespace FlyNest.Application.ViewModels.RolePermission;

public class VmPermission
{
    public string RoleId { get; set; }

    public IList<VmRoleClaims> RoleClaims { get; set; }
}

public class VmRoleClaims
{
    public string Type { get; set; }

    public string Value { get; set; }

    public bool Selected { get; set; }
}