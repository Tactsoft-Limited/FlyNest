using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FlyNest.SharedKernel.Entities.BaseEntities;

namespace FlyNest.SharedKernel.Entities;

public class Room:AuditableEntity
{
    
    [DisplayName("Room Name")]
    public string Name { get; set; }
   
    public string Facilities { get; set; }
   
    public string Benefits { get; set; }
    
    [DisplayName("Price Par Night")]
    public double PriceParNight { get; set; }
    public long HotelId { get; set; }
    public Hotel Hotel { get; set; }
    public ICollection<RoomImages> RoomImages { get; set; } = new List<RoomImages>();
}