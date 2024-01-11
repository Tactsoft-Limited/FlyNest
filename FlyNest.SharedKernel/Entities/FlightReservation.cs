using FlyNest.SharedKernel.Entities.BaseEntities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FlyNest.SharedKernel.Entities;

public class FlightReservation : AuditableEntity
{
    public string FlightType { get; set; }

    public string DepartureCity { get; set; }

    public string ArrivalCity { get; set; }

    public DateOnly FromDate { get; set; }

    public DateOnly? ToDate { get; set; }

    public string FlightClass { get; set; }

    public int Adult { get; set; }

    public int? Child { get; set; }

    public int? Infants { get; set; }

    public string ClientName { get; set; }

    public string EmailAddress { get; set; }

    public string ContactNumber { get; set; }

    public string AlternativeContact { get; set; }

    public string Status { get; set; }
}
