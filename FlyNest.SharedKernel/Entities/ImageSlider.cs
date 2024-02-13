using FlyNest.SharedKernel.Entities.BaseEntities;

namespace FlyNest.SharedKernel.Entities;

public class ImageSlider : AuditableEntity
{
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string Image { get; set; }
    public int Priority { get; set; }
    public bool IsActive { get; set; }
}
