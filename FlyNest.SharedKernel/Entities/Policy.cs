using FlyNest.SharedKernel.Entities.BaseEntities;

namespace FlyNest.SharedKernel.Entities;

public class Policy : AuditableEntity
{
    public string Description { get; set; }
    public long FlightId { get; set; }
    public Flight Flight { get; set; }
}