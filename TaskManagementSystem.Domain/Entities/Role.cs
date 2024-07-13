

using Core.Base.Entities;

namespace TaskManagementSystem.Domain.Entities;

public class Role : BaseEntity<int>
{
    public string Name { get; set; }
    public List<UserRole> UserRoles { get; set; }
}
