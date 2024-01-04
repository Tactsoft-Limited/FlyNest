using FlyNest.SharedKernel.Entities;
using FlyNest.SharedKernel.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FlyNest.Application.ViewModels.VmEntities;

public class VmRoom:BaseEntity
{
    
    [DisplayName("Room Name")]
    public string Name { get; set; }
    
    [DisplayName("Facilities")]
    public string Facilities { get; set; }
    
    [DisplayName("Benefits")]
    public string Benefits { get; set; }
   
    [DisplayName("Price Par Night")]
    public double PriceParNight { get; set; }
    public long HotelId { get; set; }
    public Hotel Hotel { get; set; }
    public ICollection<RoomImages> RoomImages { get; set; } = new List<RoomImages>();
}