using System.ComponentModel.DataAnnotations;

namespace FlyNest.Application.ViewModels.RolePermission;

public class ManageRoleClaimViewModel
{
    [Required]
    public long RoleId { get; set; }

    [Required]
    public string RoleName { get; set; }

    public string Type { get; set; }

    public string Value { get; set; }

    public bool Checked { get; set; }
}
