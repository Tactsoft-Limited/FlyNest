using AutoMapper;
using FlyNest.SharedKernel.Entities;
using FlyNest.SharedKernel.Entities.BaseEntities;

namespace FlyNest.Application.ViewModels.VmEntities;
[AutoMap(typeof(Policy),ReverseMap = true)]
public class VmPolicy:BaseEntity
{
    public string Description { get; set; }
    public long FlightId { get; set; }
    public VmFlight  Flight { get; set; }
}