using FlyNest.SharedKernel.Entities;
using FlyNest.SharedKernel.Entities.BaseEntities;

namespace FlyNest.Application.ViewModels.VmEntities;

public class VmRoomImages:BaseEntity
{
    public string RoomImage { get; set; }
    public long RoomId { get; set; }
    public Room Room { get; set; }
    public List<string> RoomImages { get; set; } = new List<string>();
}