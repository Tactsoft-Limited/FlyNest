using FlyNest.SharedKernel.Entities.BaseEntities;

namespace FlyNest.SharedKernel.Entities;

public class Stoppies : AuditableEntity
{
    public string Duration { get; set; }
    public long AirportId { get; set; }
    public Airport Airport { get; set; }
}
