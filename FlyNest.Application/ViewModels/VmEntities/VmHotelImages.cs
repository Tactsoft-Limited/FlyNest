using FlyNest.SharedKernel.Entities;
using FlyNest.SharedKernel.Entities.BaseEntities;
using Microsoft.AspNetCore.Http;

namespace FlyNest.Application.ViewModels.VmEntities;

public class VmHotelImages:BaseEntity
{
    public string HotelImage { get; set; }
    public long HotelId { get; set; }
    public Hotel Hotel { get; set; }
    
}