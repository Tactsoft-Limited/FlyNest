using FlyNest.SharedKernel.Entities.BaseEntities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace FlyNest.Application.ViewModels.VmEntities;

public class VmHotel : BaseEntity
{
    [Required]
    [DisplayName("Hotel Name")]
    public string Name { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    [DisplayName("Country Name")]
    public string CountryName { get; set; }

    [Required]
    [DisplayName("City Name")]
    public string CityName { get; set; }

    [Required]
    [DisplayName("Price Start From")]
    public double PriceStartFrom { get; set; }

    [Required]
    public int Discount { get; set; }

    [Required]
    [DisplayName("Location Map")]
    public string LocationMap { get; set; }

    [Display(Name = "Hotel Images")]
    public IFormFileCollection ImageFiles { get; set; }

    public ICollection<VmHotelImages> HotelImages { get; set; } = new List<VmHotelImages>();
}
