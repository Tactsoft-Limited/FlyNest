using FlyNest.SharedKernel.Entities.BaseEntities;

namespace FlyNest.SharedKernel.Entities;

public class Hotel:AuditableEntity
{
    public string Name { get; set; }
    public string Address { get; set;}
    public string CountryName { get; set; }
    public string CityName { get; set; }
    public double PriceStartFrom { get; set; }
    public int Discount { get; set; }
    public string LocationMap { get; set; }
    public ICollection<HotelImages> HotelImages { get; set; } = new List<HotelImages>();
    public ICollection<Room> Rooms = new HashSet<Room>();

}
