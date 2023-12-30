using FlyNest.SharedKernel.Entities.BaseEntities;

namespace FlyNest.SharedKernel.Entities.EmailSettings;

public class SMTPEmailSetting : AuditableEntity
{
    public string UserName { get; set; }

    public string Password { get; set; }

    public string Host { get; set; }

    public int Port { get; set; }

    public bool IsSSL { get; set; }

    public string FromEmail { get; set; }

    public string FromFullName { get; set; }

    public bool IsDefault { get; set; }
}
