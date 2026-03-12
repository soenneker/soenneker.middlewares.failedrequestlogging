namespace Soenneker.Middlewares.FailedRequestLogging.Abstract;

/// <summary>
/// Logs requests that fail before reaching a controller, such as 404 or invalid methods.
/// </summary>
public interface IFailedRequestLoggingMiddleware
{
}