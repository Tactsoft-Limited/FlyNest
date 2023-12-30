using FlyNest.SharedKernel.Entities.BaseEntities;

namespace FlyNest.SharedKernel.Entities.EmailSettings;

public class SendGridSetting : AuditableEntity
{
    public string SendGridUser { get; set; }

    public string SendGridKey { get; set; }

    public string FromEmail { get; set; }

    public string FromFullName { get; set; }

    public bool IsDefault { get; set; }
}
