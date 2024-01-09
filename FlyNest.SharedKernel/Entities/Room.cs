using FlyNest.SharedKernel.Entities.BaseEntities;

namespace FlyNest.SharedKernel.Entities;

public class Room : AuditableEntity
{
    public string Name { get; set; }

    public string Facilities { get; set; }

    public string Benefits { get; set; }

    public double PriceParNight { get; set; }

    public long HotelId { get; set; }

    public Hotel Hotel { get; set; }

    public ICollection<RoomImages> RoomImages { get; set; } = new HashSet<RoomImages>();
}