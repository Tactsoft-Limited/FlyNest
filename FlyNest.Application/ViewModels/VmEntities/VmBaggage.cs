using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FlyNest.SharedKernel.Entities.BaseEntities;

namespace FlyNest.Application.ViewModels.VmEntities;

public class VmBaggage:BaseEntity
{
    [Required]
    [Display(Name = "Flight Class")]
    public string FlightClass { get; set; }
    [Required]
    [Display(Name = "Luggage Weight")]
    public double LuggageWeight { get; set; }
    [Required]
    public long FlightId { get; set; }
    public VmFlight Flight { get; set; }
    [NotMapped]
    [Display(Name = "Airline Name")]
    public string AirlineName { get; set; }
}