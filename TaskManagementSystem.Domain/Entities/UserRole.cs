
using Core.Base.Entities;

namespace TaskManagementSystem.Domain.Entities;

public class UserRole : BaseEntity<int>
{
    public int RoleID { get; set; }
    public int UserID { get; set; }

    public Role Role { get; set; }
    public User User { get; set; }
}
