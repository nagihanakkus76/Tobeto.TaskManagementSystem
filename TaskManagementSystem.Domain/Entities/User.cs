
using Core.Base.Entities;

namespace TaskManagementSystem.Domain.Entities;

public class User : BaseEntity<int>
{
    public string Username { get; set; }
    public string Password { get; set; }
  
    public List<TaskEntity> Tasks { get; set; }
    public List<UserRole> UserRoles { get; set; }
}
