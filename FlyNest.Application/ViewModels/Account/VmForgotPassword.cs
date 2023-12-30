using System.ComponentModel.DataAnnotations;

namespace FlyNest.Application.ViewModels.Account;

public class VmForgotPassword
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
