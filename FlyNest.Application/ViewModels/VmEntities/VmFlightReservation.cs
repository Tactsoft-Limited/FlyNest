using FlyNest.SharedKernel.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace FlyNest.Application.ViewModels.VmEntities;

public class VmFlightReservation : BaseEntity
{
    public VmFlightReservation()
    {
        FromDate = DateOnly.FromDateTime(DateTime.Now);
        //ToDate = DateOnly.FromDateTime(DateTime.Now);
        Adult = 1;
        Child = 0;
        Infants = 0;
    }

    [Display(Name = "Flight Type")]
    [Required]
    public string FlightType { get; set; }

    [Display(Name = "Departure City")]
    [Required]
    public string DepartureCity { get; set; }

    [Display(Name = "Arrival City")]
    [Required]
    public string ArrivalCity { get; set; }

    [Display(Name = "From Date")]
    [Required]
    [DataType(DataType.Date)]
    public DateOnly FromDate { get; set; }

    [Display(Name = "Return Date")]
    [DataType(DataType.Date)]
    public DateOnly? ToDate { get; set; }

    [Display(Name = "Flight Class")]
    public string FlightClass { get; set; }

    [Display(Name = "Adult")]
    [Required]
    public int Adult { get; set; }

    [Display(Name = "Child")]
    public int? Child { get; set; }

    [Display(Name = "Infants")]
    public int? Infants { get; set; }

    [Display(Name = "Client Name")]
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

    public string Status { get; set; }
}
