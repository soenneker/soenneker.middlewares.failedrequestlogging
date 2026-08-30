using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Soenneker.Constants.Apis;
using Soenneker.Middlewares.FailedRequestLogging.Abstract;
using System.Threading.Tasks;

namespace Soenneker.Middlewares.FailedRequestLogging;

public sealed class FailedRequestLoggingMiddleware : IFailedRequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<FailedRequestLoggingMiddleware> _logger;

    public FailedRequestLoggingMiddleware(RequestDelegate next, ILogger<FailedRequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        await _next(context);

        if (context.Items.TryGetValue(ApiConstants.ControllerHitFlag, out object? controllerHit) && controllerHit is true)
            return;

        int statusCode = context.Response.StatusCode;

        if (statusCode is StatusCodes.Status400BadRequest or StatusCodes.Status404NotFound or StatusCodes.Status405MethodNotAllowed)
        {
            _logger.LogWarning("Request {Method} {Path} failed before reaching a controller with status code {StatusCode}. Trace: {TraceIdentifier}",
                context.Request.Method, context.Request.Path, statusCode, context.TraceIdentifier);
        }
    }
}
