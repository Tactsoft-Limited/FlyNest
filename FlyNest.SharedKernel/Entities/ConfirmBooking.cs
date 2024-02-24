using FlyNest.SharedKernel.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlyNest.SharedKernel.Entities;

public class ConfirmBooking : AuditableEntity
{
    public long TourPackageId { get; set; }
    public TourPackage TourPackage { get; set; }
    public double PackagePrice { get; set; }
    public string PackageTitle { get; set; }
    public string TransactionId { get; set; }
    public int TotalPerson { get; set; }
    public double TotalAmount { get; set; }
    public string ClientName { get; set; }
    public string ClientEmail { get; set; }
    public string ClientPhone { get; set; }
    public string PaymentMethod { get; set; }
    public bool TramAndCondition { get; set; }
}
