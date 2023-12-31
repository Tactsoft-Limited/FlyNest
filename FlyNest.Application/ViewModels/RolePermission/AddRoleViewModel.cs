using System.ComponentModel.DataAnnotations;

namespace FlyNest.Application.ViewModels.RolePermission;

public class AddRoleViewModel
{
    [Required]
    public string Name { get; set; }

    public string Description { get; set; }
}
