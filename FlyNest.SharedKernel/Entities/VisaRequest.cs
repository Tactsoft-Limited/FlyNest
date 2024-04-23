using FlyNest.SharedKernel.Entities.BaseEntities;

namespace FlyNest.SharedKernel.Entities;

public class VisaRequest : AuditableEntity
{
    public string CountryName { get; set; }
    public DateTime TravelDate { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string MobileNumber { get; set; }
    public string Requirements { get; set; }
}
