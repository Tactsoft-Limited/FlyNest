using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace FlyNest.Application.ViewModels.VmEntities.Search;

public class VmSearchFlight
{
    public VmSearchFlight() { DepatureDate = DateOnly.FromDateTime(DateTime.Now); }
    [Required]
    [Display(Name = "Select Depature Airport")]
    public long DepatureAirportId { get; set; }

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

    [Required]
    [Display(Name = "Date")]
    [DataType(DataType.Date)]
    public DateOnly ArrivalDate { get; set; }

    [Required]
    [Display(Name = "Time")]
    [DataType(DataType.Time)]
    public TimeOnly ArrivalTime { get; set; }

    public int Traveler { get; set; }

    public IEnumerable<SelectListItem> ArrivalAirportDropdown { get; set; } = new List<SelectListItem>();

    public IEnumerable<SelectListItem> DepatureAirportDropdown { get; set; } = new List<SelectListItem>();

    public IList<VmFlight> FlightList { get; set; } = new List<VmFlight>();
}
