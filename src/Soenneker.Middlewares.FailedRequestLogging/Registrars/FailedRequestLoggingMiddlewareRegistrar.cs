using Microsoft.AspNetCore.Builder;

namespace Soenneker.Middlewares.FailedRequestLogging.Registrars;

/// <summary>
/// Logs requests that fail before reaching a controller, such as 404 or invalid methods.
/// </summary>
public static class FailedRequestLoggingMiddlewareRegistrar
{
    public static IApplicationBuilder UseFailedRequestLogging(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<FailedRequestLoggingMiddleware>();
    }
}
