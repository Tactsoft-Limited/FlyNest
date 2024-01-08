using FlyNest.SharedKernel.Entities.BaseEntities;

namespace FlyNest.SharedKernel.Entities;

public class Baggage : AuditableEntity
{
    public string FlightClass { get; set; }
    public double LuggageWeight { get; set; }
    public long FlightId { get; set; }
    public Flight Flight { get; set; }
}