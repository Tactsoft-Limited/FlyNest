using FlyNest.SharedKernel.Entities.BaseEntities;

namespace FlyNest.SharedKernel.Entities;

public class Baggage : AuditableEntity
{
    public string FlightClass { get; set; }

    public double LuggageWeight { get; set; }

    public ICollection<Flight> Flights { get; set; } = new HashSet<Flight>();
}