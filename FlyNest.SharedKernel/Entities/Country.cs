using FlyNest.SharedKernel.Entities.BaseEntities;

namespace FlyNest.SharedKernel.Entities;

public class Country : AuditableEntity
{
    public string Name { get; set; }
    public string Image { get; set; }

    public ICollection<TourPackage> TourPackages { get; set; } = new HashSet<TourPackage>();
}
