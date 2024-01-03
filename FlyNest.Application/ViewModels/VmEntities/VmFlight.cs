using FlyNest.SharedKernel.Entities.BaseEntities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FlyNest.Application.ViewModels.VmEntities;

public class VmFlight:BaseEntity
{
    public long AirlineId { get; set; }
    [Required]
    [DisplayName("Departure Airport")]
    public string DepartureAirport { get; set; }
    [Required]
    [DataType(dataType: DataType.Date)]
    [DisplayName("Departure Date")]
    public DateOnly DepartureDate { get; set; }
    [Required]
    [DisplayName("Arrival Airport Code")]
    public string ArrivalAirportCode { get; set; }
    [Required]
    [DataType(dataType: DataType.Time)]
    [DisplayName("Arrival Time")]
    public TimeOnly ArrivalTime { get; set; }
    [Required]
    public double Price { get; set; }
    [Required]
    [DisplayName("Available Seats")]
    public string AvailableSeats { get; set; }
    [Required]
    [DisplayName("Total Seats")]
    public string TotalSeats { get; set; }
    [Required]
    [DisplayName("Aircraft Type")]
    public string AircraftType { get; set; }
    [Required]
    [DisplayName("Flight Duration")]
    public string FlightDuration { get; set; }
    [Required]
    [DisplayName("Flight Type")]
    public string FlightType { get; set; }
    public long StoppiId { get; set; }
}
