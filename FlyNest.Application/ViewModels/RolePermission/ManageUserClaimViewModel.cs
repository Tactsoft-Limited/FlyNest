using System.ComponentModel.DataAnnotations;

namespace FlyNest.Application.ViewModels.RolePermission;

public class ManageUserClaimViewModel
{
    [Required]
    public long UserId { get; set; }

    [Required]
    public string UserName { get; set; }

    public string Type { get; set; }

    public string Value { get; set; }

    public bool Checked { get; set; }
}