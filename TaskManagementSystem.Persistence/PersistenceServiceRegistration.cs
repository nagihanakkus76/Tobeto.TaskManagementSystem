using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskManagementSystem.Application.Repositories;
using TaskManagementSystem.Persistence.Context;
using TaskManagementSystem.Persistence.Repositories;

namespace TaskManagementSystem.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceService(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();

        services.AddDbContext<TaskManagementSystemDbContext>();

        return services;
    }
}