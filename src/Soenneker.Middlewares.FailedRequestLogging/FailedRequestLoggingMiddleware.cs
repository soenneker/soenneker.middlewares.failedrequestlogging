using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Soenneker.Extensions.Dictionaries.IHeader;
using Soenneker.Extensions.HttpRequests;
using Soenneker.Extensions.ValueTask;
using Soenneker.Middlewares.FailedRequestLogging.Abstract;
using System.Threading.Tasks;
using Soenneker.Constants.Apis;

namespace Soenneker.Middlewares.FailedRequestLogging;

///<inheritdoc cref="IFailedRequestLoggingMiddleware"/>
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
        context.Request.EnableBuffering();

        await _next(context);

        if (context.Items.ContainsKey(ApiConstants.ControllerHitFlag))
            return;

        int statusCode = context.Response.StatusCode;

        if (statusCode is StatusCodes.Status400BadRequest or StatusCodes.Status404NotFound or StatusCodes.Status405MethodNotAllowed)
        {
            string headers = context.Request.Headers.ToJsonString();
            string? body = await context.Request.ReadBody().NoSync();

            _logger.LogWarning("Request {Method} {Path} failed with status code {StatusCode}. Headers: {Headers} Body: {Body}", context.Request.Method,
                context.Request.Path + context.Request.QueryString, statusCode, headers, body);
        }
    }
}