using Core.Base.Repos.Concrete;
using TaskManagementSystem.Application.Repositories;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Persistence.Context;

namespace TaskManagementSystem.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(TaskManagementSystemDbContext context) : base(context)
    {
    }
}
