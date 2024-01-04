using FlyNest.SharedKernel.Entities.BaseEntities;
using System.ComponentModel;

namespace FlyNest.SharedKernel.Entities;

public class RoomImages : AuditableEntity
{
    public RoomImages()
    {
        Room = new Room();
    }
    [DisplayName("Room Image")]
    public string RoomImage { get; set; }
    public long RoomId { get;set; }
    public Room Room { get; set; }
}