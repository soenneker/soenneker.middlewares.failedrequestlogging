using Microsoft.AspNetCore.Builder;

namespace Soenneker.Middlewares.FailedRequestLogging.Registrars;

/// <summary>
/// Logs requests that fail before reaching a controller, such as 404 or invalid methods.
/// </summary>
public static class FailedRequestLoggingMiddlewareRegistrar
{
    /// <summary>
    /// Adds the use failed request logging failed request logging middleware utility to the class list.
    /// </summary>
    /// <param name="builder">Builder to configure.</param>
    /// <returns>The same builder instance, so additional classes or variants can be chained.</returns>
    public static IApplicationBuilder UseFailedRequestLogging(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<FailedRequestLoggingMiddleware>();
    }
}
