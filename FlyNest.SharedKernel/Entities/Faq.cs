using FlyNest.SharedKernel.Entities.BaseEntities;

namespace FlyNest.SharedKernel.Entities;

public class Faq : AuditableEntity
{
    public string Category { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
}
