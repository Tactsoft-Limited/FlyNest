using FlyNest.SharedKernel.Entities.BaseEntities;

namespace FlyNest.SharedKernel.Entities;

public class Stopover : AuditableEntity
{
    public long AirportId { get; set; }

    public Airport StopoverAirport { get; set; }

    public DateOnly StopoverDate { get; set; }

    public TimeOnly StopoverTime { get; set; }

    public long FlightId { get; set; }

    public Flight Flight { get; set; }
}