using FlyNest.SharedKernel.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace FlyNest.Application.ViewModels.VmEntities;

public class VmVisaRequest : BaseEntity
{
    [Display(Name = "Country Name")]
    [Required(ErrorMessage = "Country name is required")]
    [StringLength(120, ErrorMessage = "Country name must be less than 120 characters")]
    public string CountryName { get; set; }

    [Display(Name = "Travel Date")]
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Travel date is required")]
    public DateTime TravelDate { get; set; } = DateTime.Now;

    [Display(Name = "First Name")]
    [Required(ErrorMessage = "First name is required")]
    [StringLength(85, ErrorMessage = "First name must be less than 85 characters")]
    public string FirstName { get; set; }

    [Display(Name = "Last Name")]
    [Required(ErrorMessage = "Last name is required")]
    [StringLength(85, ErrorMessage = "Last name must be less than 85 characters")]
    public string LastName { get; set; }

    [Display(Name = "Email Address")]
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    [StringLength(85, ErrorMessage = "Email must be less than 85 characters")]
    public string Email { get; set; }

    [Display(Name = "Mobile Number")]
    [Required(ErrorMessage = "Mobile number is required")]
    [StringLength(20, ErrorMessage = "Mobile number must be less than 20 characters")]
    public string MobileNumber { get; set; }

    [Display(Name = "Your Requirements")]
    [Required(ErrorMessage = "Requirements are required")]
    [StringLength(500, ErrorMessage = "Requirements must be less than 500 characters")]
    public string Requirements { get; set; }
}
