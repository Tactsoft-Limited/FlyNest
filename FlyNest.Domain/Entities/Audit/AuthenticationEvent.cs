using FlyNest.SharedKernel.Entities.BaseEntities;

namespace FlyNest.SharedKernel.Entities.Audit;

public class AuthenticationEvent : BaseEntity
{
    public long UserId { get; set; }

    public string UserName { get; set; }

    public DateTimeOffset LoginTime { get; set; }

    public DateTimeOffset? LogoutTime { get; set; }

    public string IPAddress { get; set; }
}
