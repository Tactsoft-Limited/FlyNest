using FlyNest.SharedKernel.Core.Helpers;

namespace FlyNest.Application.ViewModels.RolePermission;

public class ManageUserPermissionsViewModel
{
    public long UserId { get; set; }

    public string UserName { get; set; }

    public string PermissionValue { get; set; }

    public PaginatedList<ManageUserClaimViewModel> ManagePermissionsViewModel { get; set; }
}
