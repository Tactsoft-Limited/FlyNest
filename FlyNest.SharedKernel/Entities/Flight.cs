using FlyNest.SharedKernel.Entities.BaseEntities;

namespace FlyNest.SharedKernel.Entities;

public class Flight:AuditableEntity
{
    public long AirlineId { get; set; }

    public string DepartureAirport { get; set; }

    public DateOnly DepartureDate { get; set; }

    public string ArrivalAirportCode { get; set; }

    public TimeOnly ArrivalTime { get; set; }

    public double Price { get; set; }

    public string AvailableSeats { get; set; }

    public string TotalSeats { get; set; }

    public string AircraftType { get; set; }

    public string FlightDuration { get; set; }

    public string FlightType { get; set; }
    public long StoppieId { get; set; }
    public  Airline Airline { get; set; }
    public  Stoppies  Stoppies { get; set; }
}
