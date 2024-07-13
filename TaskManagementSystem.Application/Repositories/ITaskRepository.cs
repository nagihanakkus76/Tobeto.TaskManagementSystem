using Core.Base.Repos.Abstracts;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Repositories;

public interface ITaskRepository : IBaseRepository<TaskEntity>
{
}
