using FlyNest.SharedKernel.Core.Helpers;
using System.ComponentModel.DataAnnotations;

namespace FlyNest.Application.ViewModels.RolePermission;

public class ManageRolePermissionsViewModel
{
    [Required]
    public long RoleId { get; set; }

    public string RoleName { get; set; }

    public string PermissionValue { get; set; }

    public PaginatedList<ManageClaimViewModel> ManagePermissionsViewModel { get; set; }
}
