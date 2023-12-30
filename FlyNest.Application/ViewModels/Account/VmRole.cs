using FlyNest.SharedKernel.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace FlyNest.Application.ViewModels.Account;

public class VmRole : BaseEntity
{
    [Required]
    [Display(Name = "Role Name")]
    public string RoleName { get; set; }

    public string Description { get; set; }

    public int NumberOfUsers { get; set; }
}
