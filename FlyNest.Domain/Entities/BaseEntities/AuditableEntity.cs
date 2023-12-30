namespace FlyNest.SharedKernel.Entities.BaseEntities;

public class AuditableEntity<TId> : BaseEntity<TId>
{
    public AuditableEntity() { IsDelete = false; }

    public DateTimeOffset CreatedDate { get; set; }

    public long CreatedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public long? ModifiedBy { get; set; }

    public bool IsDelete { get; set; }

    public int UpdateNo { get; set; }
}

// abstract class
public class AuditableEntity : AuditableEntity<long>
{
}
