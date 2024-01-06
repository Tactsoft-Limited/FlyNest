using FlyNest.SharedKernel.Entities.BaseEntities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace FlyNest.Application.ViewModels.VmEntities;

public class VmStopover : BaseEntity
{
    public long FlightId { get; set; }

    [Display(Name = "Flight Number")]
    public string FlightNo { get; set; }

    [Display(Name = "Select Stopover Airport")]
    public long AirportId { get; set; }

    [Display(Name = "Stopover Airport Name")]
    public string StopoverAirportName { get; set; }

    [Display(Name = "Stopover Date")]
    [DataType(DataType.Date)]
    public DateOnly StopoverDate { get; set; }

    [Display(Name = "Stopover Time")]
    [DataType(DataType.Time)]
    public TimeOnly StopoverTime { get; set; }

    public IEnumerable<SelectListItem> AirportDropdown { get; set; } = new List<SelectListItem>();
}