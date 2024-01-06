using FlyNest.SharedKernel.Entities;
using FlyNest.SharedKernel.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using JetBrains.Annotations;

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
    [NotMapped]
    [DisplayName("Hotel Name")]
    public string HotelName { get; set; }
    [CanBeNull]
    public List<IFormFile> Files { get; set; }
    public ICollection<VmRoomImages> RoomImages { get; set; } = new List<VmRoomImages>();
}