using FlyNest.SharedKernel.Entities.BaseEntities;

namespace FlyNest.Application.ViewModels.VmEntities;

public class VmPolicy:BaseEntity
{
    public string Description { get; set; }
    public long FlightId { get; set; }
    public VmFlight  Flight { get; set; }
}