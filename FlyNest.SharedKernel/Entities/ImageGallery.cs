using FlyNest.SharedKernel.Entities.BaseEntities;

namespace FlyNest.SharedKernel.Entities;

public class ImageGallery : AuditableEntity
{
    public string EventTitle { get; set; }
    public DateTime EventDate { get; set; }
    public string ImageUrl { get; set; }
}
