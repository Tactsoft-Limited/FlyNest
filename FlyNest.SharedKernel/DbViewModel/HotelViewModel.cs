using FlyNest.SharedKernel.Entities.BaseEntities;

namespace FlyNest.SharedKernel.DbViewModel;

public class HotelViewModel:BaseEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string CountryName { get; set; }
    public string CityName { get; set; }
    public double PriceStartFrom { get; set; }
    public double Discount { get; set; }
    public string HotelImage { get; set; }
    public string LocationMap { get; set; }
}