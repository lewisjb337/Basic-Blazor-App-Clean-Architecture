namespace DEMO.Domain.Shared;

public class BaseEntity
{
	public int Id { get; set; }
	public Guid? Key { get; set; }
	public DateTime DateCreated { get; set; }
	public DateTime? DateModified { get; set; }
}