using Core.Base.Entities;
using TaskManagementSystem.Domain.Enum;

namespace TaskManagementSystem.Domain.Entities;

public class TaskEntity : BaseEntity<int>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;

    public int UserID { get; set; }
    public User User { get; set; }
    public Status Status { get; set; } = Status.New;
}
