
﻿using FlyNest.SharedKernel.Entities.BaseEntities;

﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FlyNest.SharedKernel.Entities.BaseEntities;

using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FlyNest.Application.ViewModels.VmEntities;
public class VmHotel:BaseEntity
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
    [CanBeNull]
    public List<IFormFile> File { get; set; }

    [NotMapped]
    public string Image { get; set; }
    public ICollection<VmHotelImages> HotelImages { get; set; } = new List<VmHotelImages>();
}
