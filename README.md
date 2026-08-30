# Soenneker.Middlewares.FailedRequestLogging
[![](https://img.shields.io/nuget/v/soenneker.middlewares.failedrequestlogging.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.middlewares.failedrequestlogging/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.middlewares.failedrequestlogging/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.middlewares.failedrequestlogging/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.middlewares.failedrequestlogging.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.middlewares.failedrequestlogging/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.middlewares.failedrequestlogging/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.middlewares.failedrequestlogging/actions/workflows/codeql.yml)

Logs `400`, `404`, and `405` responses for ASP.NET Core requests that did not reach an MVC controller.

## Installation

```bash
dotnet add package Soenneker.Middlewares.FailedRequestLogging
```

## Registration

Add the middleware after routing and before controller endpoints execute:

```csharp
using Soenneker.Middlewares.FailedRequestLogging.Registrars;

app.UseRouting();
app.UseFailedRequestLogging();

app.MapControllers();
```

For the middleware to distinguish controller responses from failures that occurred before a controller, register `Soenneker.Filters.PreControllerLogging` globally:

```bash
dotnet add package Soenneker.Filters.PreControllerLogging
```

```csharp
using Soenneker.Filters.PreControllerLogging.Registrars;

builder.Services.AddControllers(options =>
{
    options.Filters.AddPreControllerLoggingFilter();
});
```

That filter sets the shared controller-hit marker before an action runs. Without it, the middleware also logs matching status codes returned by controllers because no marker is present.

## Logged data

Each warning contains the HTTP method, path, status code, and ASP.NET Core trace identifier. Query strings, headers, cookies, authorization values, and request bodies are deliberately omitted. This avoids buffering attacker-controlled bodies and putting common credentials or personal data into logs.

The middleware does not change the response and does not log controller-handled failures, other status codes, or exceptions thrown by later middleware. Use ASP.NET Core exception handling and normal request logging for those cases.

Paths can still contain identifiers or other sensitive values. Apply suitable log access controls and retention policies.
