using FlyNest.SharedKernel.Entities.BaseEntities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace FlyNest.Application.ViewModels.VmEntities;

public class VmFlight : BaseEntity
{
    [Required]
    [Display(Name = "Flight Numner")]
    public string FlightNo { get; set; }

    [Required]
    [Display(Name = "Select Airline")]
    public long AirlineId { get; set; }

    [Display(Name = "Airline Name")]
    public string AirlineName { get; set; }

    public string AirlineLogo { get; set; }

    [Required]
    [Display(Name = "Select Depature Airport")]
    public long DepatureAirportId { get; set; }

    [Display(Name = "Depature Airport")]
    public string DepatureAirportName { get; set; }

    public string DepatureAirportCode { get; set; }

    [Required]
    [Display(Name = "Date")]
    [DataType(DataType.Date)]
    public DateOnly DepatureDate { get; set; }

    [Required]
    [Display(Name = "Time")]
    [DataType(DataType.Time)]
    public TimeOnly DepatureTime { get; set; }

    [Required]
    [Display(Name = "Select Arrival Airport")]
    public long ArrivalAirportId { get; set; }

    [Display(Name = "Arrival Airport")]
    public string ArrivalAirportName { get; set; }

    public string ArrivalAirportCode { get; set; }

    [Required]
    [Display(Name = "Date")]
    [DataType(DataType.Date)]
    public DateOnly ArrivalDate { get; set; }

    [Required]
    [Display(Name = "Time")]
    [DataType(DataType.Time)]
    public TimeOnly ArrivalTime { get; set; }

    [Required]
    public double Price { get; set; }

    [Display(Name = "Aircraft Type")]
    public string AircraftType { get; set; }

    [Display(Name = "Flight Duration")]
    public TimeSpan FlightDuration { get; set; }

    [Display(Name = "Flight Type")]
    public string FlightType { get; set; }

    public VmAirline VmAirline { get; set; }

    public ICollection<VmStopover> Stopovers { get; set; } = new HashSet<VmStopover>();

    public IEnumerable<SelectListItem> AirlineDropdown { get; set; } = new List<SelectListItem>();

    public IEnumerable<SelectListItem> AirportDropdown { get; set; } = new List<SelectListItem>();
}
