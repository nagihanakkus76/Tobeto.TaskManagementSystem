using Core.Application.Exceptions.HttpProblemDetails;
using Core.Application.Exceptions.Types;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Core.Application.Exceptions;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context); // herhangi bir işlem
        }
        catch (Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            if (exception is ValidationException)
            {
                ValidationException validationException = (ValidationException)exception;

                ValidationProblemDetails validationProblemDetails = new ValidationProblemDetails(validationException.Errors.ToList());

                await context.Response.WriteAsync(JsonSerializer.Serialize(validationProblemDetails));
            }
            else if (exception is CustomException)
            {
                ProblemDetails problemDetails = new ProblemDetails();
                problemDetails.Title = "Exception";
                problemDetails.Detail = exception.Message;
                problemDetails.Type = "Custom Exception";
                await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("Bilinmedik Hata");
            }
        }
    }
}
