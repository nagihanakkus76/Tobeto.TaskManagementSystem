namespace Core.Base.Entities.Auditing;

public interface ISoftDeletable
{
	public bool IsDeleted { get; set; }
}
