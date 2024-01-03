using System.ComponentModel.DataAnnotations;

namespace FlyNest.Application.ViewModels.RolePermission;

public class ManageUserRolesViewModel
{
    [Required]
    public string UserId { get; set; }

    public string UserName { get; set; }

    public IList<ManageRoleViewModel> ManageRolesViewModel { get; set; }
}