using FlyNest.SharedKernel.Entities.BaseEntities;

using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;

using System.ComponentModel.DataAnnotations;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlyNest.Application.ViewModels.VmEntities;

public class VmRoom:BaseEntity
{
    [DisplayName("Room Name")]
    [Required]
    public string Name { get; set; }
    [DisplayName("Facilities")]
    [Required]
    public string Facilities { get; set; }
    [DisplayName("Benefits")]
    [Required]
    public string Benefits { get; set; }
    [DisplayName("Price Par Night")]
    [Required]
    public double PriceParNight { get; set; }
    public long HotelId { get; set; }
    public VmHotel Hotel { get; set; }
    [NotMapped]
    [DisplayName("Hotel Name")]
    public string HotelName { get; set; }
    [CanBeNull]
    public List<IFormFile> Files { get; set; }
    public ICollection<VmRoomImages> RoomImages { get; set; } = new List<VmRoomImages>();
}