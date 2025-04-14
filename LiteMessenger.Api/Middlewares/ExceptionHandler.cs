using System.Net;
using LiteMessenger.Domain.Exceptions;

namespace LiteMessenger.Api.Middlewares;

public class ExceptionHandler
{
    private readonly ILogger<ExceptionHandler> _logger;
    private readonly RequestDelegate _next;

    public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (RegisterNotFoundException ex)
        {
            var errorResponse = new ErrorResponse(ex.Message);

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            await httpContext.Response.WriteAsJsonAsync(errorResponse);
        }
        catch (ValidationException ex)
        {
            var errorResponse = new ErrorResponse(ex.Message);

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await httpContext.Response.WriteAsJsonAsync(errorResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred: {Message}", ex.Message);

            var errorResponse = new ErrorResponse(ex.Message);

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(errorResponse);
        }
    }
}
