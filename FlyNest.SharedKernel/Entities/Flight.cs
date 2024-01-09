using FlyNest.SharedKernel.Entities.BaseEntities;

namespace FlyNest.SharedKernel.Entities;

public class Flight : AuditableEntity
{
    public string FlightNo { get; set; }

    public long AirlineId { get; set; }

    public Airline Airline { get; set; }

    public long DepatureAirportId { get; set; }

    public Airport DepatureFlight { get; set; }

    public DateOnly DepatureDate { get; set; }

    public TimeOnly DepatureTime { get; set; }

    public long ArrivalAirportId { get; set; }

    public Airport ArrivalFlight { get; set; }

    public DateOnly ArrivalDate { get; set; }

    public TimeOnly ArrivalTime { get; set; }

    public double Price { get; set; }

    public string AircraftType { get; set; }

    public TimeSpan FlightDuration { get; set; }

    public string FlightType { get; set; }

    

    public ICollection<Stopover> Stopovers { get; set; } = new HashSet<Stopover>();
    public ICollection<Baggage> Baggages { get; set; } = new HashSet<Baggage>();
    public ICollection<Policy> Policies { get; set; } = new HashSet<Policy>();
}
