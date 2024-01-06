using FlyNest.SharedKernel.Entities.BaseEntities;
using System.ComponentModel;

namespace FlyNest.Application.ViewModels.VmEntities;

public class VmRoomImages:BaseEntity
{
    [DisplayName("Room Image")]
    public string RoomImage { get; set; }
    public long RoomId { get; set; }
    public VmRoom Room { get; set; }
    
}