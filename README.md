[![](https://img.shields.io/nuget/v/soenneker.middlewares.failedrequestlogging.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.middlewares.failedrequestlogging/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.middlewares.failedrequestlogging/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.middlewares.failedrequestlogging/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.middlewares.failedrequestlogging.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.middlewares.failedrequestlogging/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.middlewares.failedrequestlogging/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.middlewares.failedrequestlogging/actions/workflows/codeql.yml)

# Soenneker.Middlewares.FailedRequestLogging

Logs requests that fail before reaching a controller, such as 404 or invalid methods.

## Install

```bash
dotnet add package Soenneker.Middlewares.FailedRequestLogging
```

## Quick start

```csharp
using Soenneker.Middlewares.FailedRequestLogging.Registrars;

IApplicationBuilder builder = /* obtain from your application */;
var result = builder.UseFailedRequestLogging();
```

Adds the use failed request logging failed request logging middleware utility to the class list.

## What you get

- `IFailedRequestLoggingMiddleware` — Logs requests that fail before reaching a controller, such as 404 or invalid methods.
- `FailedRequestLoggingMiddlewareRegistrar` — Logs requests that fail before reaching a controller, such as 404 or invalid methods.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `FailedRequestLoggingMiddlewareRegistrar.UseFailedRequestLogging(builder)` | Adds the use failed request logging failed request logging middleware utility to the class list. | The same builder instance, so additional classes or variants can be chained. |
