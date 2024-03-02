using FlyNest.SharedKernel.Entities.BaseEntities;

namespace FlyNest.SharedKernel.Entities;

public class VisaRequirement : AuditableEntity
{
    public long CountryId { get; set; }
    public Country Country { get; set; }
    public string BasicDocument { get; set; }
    public string ForBusinessPerson { get; set; }
    public string ForJobHolder { get; set; }
    public string ForStudent { get; set; }
    public string ForMedical { get; set; }
    public string VisaFee { get; set; }
    public string Others { get; set; }
}
