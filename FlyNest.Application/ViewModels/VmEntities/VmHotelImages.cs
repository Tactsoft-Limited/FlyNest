using FlyNest.SharedKernel.Entities.BaseEntities;
using System.ComponentModel;

namespace FlyNest.Application.ViewModels.VmEntities;

public class VmHotelImages : BaseEntity
{
    [DisplayName("Hotel Image")]
    public string HotelImage { get; set; }

    public long HotelId { get; set; }

    public VmHotel Hotel { get; set; }
}