using Core.Application.Helpers.Converters.DateConverter;
using Core.Utilities.JWT;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core
{
    public static class CoreServiceRegistiration
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, TokenOptions tokenOptions)
        {
            services.AddScoped<ITokenHelper, JwtHelper>(_ => new JwtHelper(tokenOptions));
            services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
                options.JsonSerializerOptions.Converters.Add(new TimeOnlyJsonConverter());
            });
            return services;
        }
    }
}
