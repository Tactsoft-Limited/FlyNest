using FlyNest.SharedKernel.Entities.BaseEntities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FlyNest.Application.ViewModels.VmEntities;

public class VmAirport : BaseEntity
{
    [Required]
    [Display(Name = "Airport Name")]
    public string Name { get; set; }

    [Required]
    [Display(Name = "Airport Code")]
    [Remote("IsCodeExist", "Airport", ErrorMessage = "Airport code is already exists")]
    public string Code { get; set; }

    [Required]
    [Display(Name = "Country Name")]
    public string CountryName { get; set; }

    [Required]
    [Display(Name = "City Name")]
    public string CityName { get; set; }
}
