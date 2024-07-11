using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace RPSLSGame.Common;

/// <summary>
/// A middleware for handling exceptions globally.
/// </summary>
public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        var statusCode = exception switch
        {
            ArgumentException => HttpStatusCode.BadRequest,
            _ => HttpStatusCode.InternalServerError
        };

        var problemDetails = new ProblemDetails
        {
            Status = (int)statusCode,
            Title = statusCode == HttpStatusCode.InternalServerError
                ? "An unexpected error occurred"
                : exception.Message,
            Detail = statusCode == HttpStatusCode.InternalServerError
                ? "Please try again later."
                : exception.Message,
            Instance = httpContext.Request.Path
        };

        _logger.LogError(exception, exception.Message);

        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = (int)statusCode;
        await httpContext.Response.WriteAsJsonAsync(problemDetails,
            cancellationToken: cancellationToken);

        return true;
    }
}
