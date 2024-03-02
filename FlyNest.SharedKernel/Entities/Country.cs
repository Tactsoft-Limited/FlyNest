using FlyNest.SharedKernel.Entities.BaseEntities;

namespace FlyNest.SharedKernel.Entities;

public class Country : AuditableEntity
{
    public string Name { get; set; }
    public string CapitalCity { get; set; }
    public string LocalTime { get; set; }
    public string TelephoneCode { get; set; }
    public string BankTime { get; set; }
    public string EmbassyAddress { get; set; }
    public string Description { get; set; }
    public string Language { get; set; }
    public string Currency { get; set; }
    public string TourismPlace { get; set; }
    public string Image { get; set; }

    public ICollection<TourPackage> TourPackages { get; set; } = new HashSet<TourPackage>();
    public ICollection<VisaRequirement> VisaRequirements { get; set; } = new HashSet<VisaRequirement>();
}
