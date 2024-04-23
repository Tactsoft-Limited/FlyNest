using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace FlyNest.Application.ViewModels.VmEntities.Search;

public class VmSearchFlight
{
    public VmSearchFlight()
    {
        DepatureDate = DateOnly.FromDateTime(DateTime.Now);
        CheckInDate = DateOnly.FromDateTime(DateTime.Now);
        CheckOutDate = DateOnly.FromDateTime(DateTime.Now);
    }

    [Required]
    [Display(Name = "Select Depature Airport")]
    public long DepatureAirportId { get; set; }


    [Display(Name = "Date")]
    [DataType(DataType.Date)]
    public DateOnly DepatureDate { get; set; }


    [Display(Name = "Time")]
    [DataType(DataType.Time)]
    public TimeOnly DepatureTime { get; set; }


    [Display(Name = "Select Arrival Airport")]
    public long ArrivalAirportId { get; set; }


    [Display(Name = "Date")]
    [DataType(DataType.Date)]
    public DateOnly ArrivalDate { get; set; }

    [Display(Name = "Time")]
    [DataType(DataType.Time)]
    public TimeOnly ArrivalTime { get; set; }

    public int Traveler { get; set; }

    //Hotel Search

    [Display(Name = "Select Hotel")]
    public long HotelId { get; set; }

    [Display(Name = "Check-In Date")]
    public DateOnly CheckInDate { get; set; }

    [Display(Name = "Check-Out Date")]
    public DateOnly CheckOutDate { get; set; }

    [Display(Name = "Guest")]
    public int NumberOfGuest { get; set; }

    public IEnumerable<SelectListItem> ArrivalAirportDropdown { get; set; } = [];

    public IEnumerable<SelectListItem> DepatureAirportDropdown { get; set; } = [];

    public IEnumerable<SelectListItem> HotelDropdown { get; set; } = [];

    public IList<VmHotel> HotelList { get; set; } = [];

    public IList<VmFlight> FlightList { get; set; } = [];
}
