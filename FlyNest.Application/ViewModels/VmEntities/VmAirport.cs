using FlyNest.SharedKernel.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace FlyNest.Application.ViewModels.VmEntities;

public class VmAirport : BaseEntity
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Code { get; set; }

    [Required]
    [Display(Name = "Country Name")]
    public string CountryName { get; set; }

    [Required]
    [Display(Name = "City Name")]
    public string CityName { get; set; }
}
