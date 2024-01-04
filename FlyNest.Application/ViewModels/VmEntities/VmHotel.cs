using AutoMapper;
using FlyNest.SharedKernel.Entities;
using FlyNest.SharedKernel.Entities.BaseEntities;

namespace FlyNest.Application.ViewModels.VmEntities;
[AutoMap(typeof(Hotel), ReverseMap = true)] 
public class VmHotel:BaseEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string CountryName { get; set; }
    public string CityName { get; set; }
    public double PriceStartFrom { get; set; }
    public int Discount { get; set; }
    public string locationMap { get; set; }
    public ICollection<VmHotelImages> HotelImages { get; set; } = new List<VmHotelImages>();
}
