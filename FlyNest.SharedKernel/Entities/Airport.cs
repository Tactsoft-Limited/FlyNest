using FlyNest.SharedKernel.Entities.BaseEntities;

namespace FlyNest.SharedKernel.Entities;

public class Airport : AuditableEntity
{
    public string Name { get; set; }

    public string Code { get; set; }

    public string CountryName { get; set; }

    public string CityName { get; set; }
    public ICollection<Stoppies> Stoppies = new HashSet<Stoppies>();
}
