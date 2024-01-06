using FlyNest.SharedKernel.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace FlyNest.Application.ViewModels.VmEntities;

public class VmAirline : BaseEntity
{
    [Required]
    [Display(Name = "Airline Name")]
    public string AirlineName { get; set; }

    [Required]
    [Display(Name = "Contact")]
    public string ContactInfo { get; set; }

    [Required]
    public string Website { get; set; }

    public string Logo { get; set; }

    [Display(Name = "Established Date")]
    public DateOnly EstablishedDate { get; set; }
}
