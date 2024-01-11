using FlyNest.SharedKernel.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace FlyNest.Application.ViewModels.VmEntities;

public class VmHotelReservation : BaseEntity
{
    public VmHotelReservation()
    {
        FromDate = DateOnly.FromDateTime(DateTime.Now);
        ToDate = DateOnly.FromDateTime(DateTime.Now);
        Adult = 1;
        Child = 0;
    }


    [Display(Name = "City Name")]
    [Required]
    public string CityName { get; set; }

    [Display(Name = "Preference Hotel")]
    public string PreferenceHotel { get; set; }


    [Display(Name = "From Date")]
    [DataType(DataType.Date)]
    [Required]
    public DateOnly FromDate { get; set; }


    [Display(Name = "To Date")]
    [DataType(DataType.Date)]
    [Required]
    public DateOnly ToDate { get; set; }


    [Display(Name = "Adult")]
    [Required]
    public int Adult { get; set; }

    [Display(Name = "Child")]
    public int? Child { get; set; }

    [Display(Name = "ClientName Name")]
    [Required]
    public string ClientName { get; set; }

    [Display(Name = "Email Address")]
    [DataType(DataType.EmailAddress)]
    public string EmailAddress { get; set; }

    [Display(Name = "Mobile")]
    [Required]
    [DataType(DataType.PhoneNumber)]
    public string ContactNumber { get; set; }

    [Display(Name = "Phone")]
    [DataType(DataType.PhoneNumber)]
    public string AlternativeContact { get; set; }
}

