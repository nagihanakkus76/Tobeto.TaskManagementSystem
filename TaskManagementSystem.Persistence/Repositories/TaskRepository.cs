using Core.Base.Repos.Concrete;
using TaskManagementSystem.Application.Repositories;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Persistence.Context;

namespace TaskManagementSystem.Persistence.Repositories;

public class TaskRepository : BaseRepository<TaskEntity>, ITaskRepository
{
    public TaskRepository(TaskManagementSystemDbContext context) : base(context)
    {
    }
}
