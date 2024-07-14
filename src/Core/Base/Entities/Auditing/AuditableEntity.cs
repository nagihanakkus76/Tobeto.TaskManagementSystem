namespace Core.Base.Entities.Auditing;

public class AuditableEntity<T> : BaseEntity<T>
{
	public DateTimeOffset? CreatedDate { get; set; }
	public string? CreatedBy { get; set; }

	public DateTimeOffset? ModifiedDate { get; set; }
	public string? ModifiedBy { get; set; }

	public DateTimeOffset? DeletedDate { get; set; }
	public string? DeletedBy { get; set; }
}
