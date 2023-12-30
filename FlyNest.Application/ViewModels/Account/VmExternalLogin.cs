using System.ComponentModel.DataAnnotations;

namespace FlyNest.Application.ViewModels.Account;

public class VmExternalLogin
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
