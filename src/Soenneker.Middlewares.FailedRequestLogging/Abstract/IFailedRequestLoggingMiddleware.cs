using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Soenneker.Middlewares.FailedRequestLogging.Abstract;

/// <summary>
/// Logs selected HTTP failures that occur before a request reaches an MVC controller.
/// </summary>
public interface IFailedRequestLoggingMiddleware
{
    /// <summary>
    /// Invokes the middleware for the supplied HTTP context.
    /// </summary>
    /// <param name="context">Current HTTP context.</param>
    /// <returns>A task that completes after the remaining request pipeline and any required logging finish.</returns>
    Task Invoke(HttpContext context);
}
