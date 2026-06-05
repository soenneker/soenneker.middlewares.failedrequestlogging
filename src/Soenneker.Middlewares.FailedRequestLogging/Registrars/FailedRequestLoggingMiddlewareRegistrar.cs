using Microsoft.AspNetCore.Builder;

namespace Soenneker.Middlewares.FailedRequestLogging.Registrars;

/// <summary>
/// Logs requests that fail before reaching a controller, such as 404 or invalid methods.
/// </summary>
public static class FailedRequestLoggingMiddlewareRegistrar
{
    /// <summary>
    /// Executes the use failed request logging operation.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The result of the operation.</returns>
    public static IApplicationBuilder UseFailedRequestLogging(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<FailedRequestLoggingMiddleware>();
    }
}
