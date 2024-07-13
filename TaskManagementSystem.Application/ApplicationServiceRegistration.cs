using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TaskManagementSystem.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
        });
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}