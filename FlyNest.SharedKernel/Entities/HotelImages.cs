using FlyNest.SharedKernel.Entities.BaseEntities;

namespace FlyNest.SharedKernel.Entities;

public class HotelImages: AuditableEntity
{
    public string HotelImage { get; set; }
    public long HotelId { get; set; }
   public Hotel Hotel { get;set; }
}