using FlyNest.SharedKernel.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace FlyNest.SharedKernel.Entities.Audit;

public class AuditLog : BaseEntity
{
    public long? UserId { get; set; }

    public string AuditType { get; set; }

    public string TableName { get; set; }

    public DateTimeOffset DateTime { get; set; }

    public string OldValues { get; set; }

    public string NewValues { get; set; }

    public string AffectedColumns { get; set; }

    public string PrimaryKey { get; set; }
}

public class AuditEntry(EntityEntry entry)
{
    public EntityEntry Entry { get; } = entry;

    public long UserId { get; set; }

    public string TableName { get; set; }

    public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();

    public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();

    public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();

    public AuditType AuditType { get; set; }

    public List<string> ChangedColumns { get; } = new List<string>();

    public AuditLog ToAuditLog()
    {
        var audit = new AuditLog
        {
            UserId = UserId,
            AuditType = AuditType.ToString(),
            TableName = TableName,
            DateTime = DateTimeOffset.UtcNow,
            PrimaryKey = JsonConvert.SerializeObject(KeyValues),
            OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues),
            NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues),
            AffectedColumns = ChangedColumns.Count == 0 ? null : JsonConvert.SerializeObject(ChangedColumns)
        };

        return audit;
    }
}

public enum AuditType
{
    None = 0,
    Create = 1,
    Update = 2,
    Delete = 3
}
