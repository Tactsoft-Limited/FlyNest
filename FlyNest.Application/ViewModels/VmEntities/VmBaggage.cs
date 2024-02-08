using FlyNest.SharedKernel.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace FlyNest.Application.ViewModels.VmEntities;

public class VmBaggage : BaseEntity
{
    [Required]
    [Display(Name = "Flight Class")]
    public string FlightClass { get; set; }

    [Required]
    [Display(Name = "Weight Per Person")]
    public double LuggageWeight { get; set; }
}