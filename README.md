[![](https://img.shields.io/nuget/v/soenneker.html.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.html.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.html.client/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.html.client/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.html.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.html.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.html.client/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.html.client/actions/workflows/codeql.yml)

# Soenneker.Html.Client

A .NET HTTP client for HTML parsing.

## Install

```bash
dotnet add package Soenneker.Html.Client
```

## Quick start

```csharp
using Soenneker.Html.Client.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddHtmlClientAsSingleton();
```

Adds `IHtmlClient` as a singleton service.

## What you get

- `IHtmlClient` — A .NET HTTP client for HTML parsing.
- `HtmlClientRegistrar` — A .NET HTTP client for HTML parsing.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `HtmlClientRegistrar.AddHtmlClientAsSingleton(services)` | Adds `IHtmlClient` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `HtmlClientRegistrar.AddHtmlClientAsScoped(services)` | Adds `IHtmlClient` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Dispose instances you own when their scope ends so held resources can be released.
