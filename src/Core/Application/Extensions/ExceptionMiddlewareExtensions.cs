using Core.Application.Exceptions;
using Microsoft.AspNetCore.Builder;

namespace Core.Application.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionMiddlewareExtensions(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}
