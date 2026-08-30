[![](https://img.shields.io/nuget/v/soenneker.html.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.html.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.html.client/build-and-test.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.html.client/actions/workflows/build-and-test.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.html.client/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.html.client/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.html.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.html.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.html.client/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.html.client/actions/workflows/codeql.yml)

# Soenneker.Html.Client

Provides a cached, dependency-injection-friendly `HttpClient` for retrieving HTML.

## Install

```bash
dotnet add package Soenneker.Html.Client
```

## Register

```csharp
using Soenneker.Html.Client.Registrars;

services.AddHtmlClientAsSingleton();
```

Use `AddHtmlClientAsScoped()` when each dependency-injection scope must own an independent client. Its cache is scoped as well, so disposing one scope cannot remove another scope's client.

## Usage

```csharp
using Soenneker.Html.Client.Abstract;

public sealed class PageLoader(IHtmlClient htmlClient)
{
    public async Task<string> Load(Uri uri, CancellationToken cancellationToken)
    {
        HttpClient client = await htmlClient.Get(cancellationToken);

        return await client.GetStringAsync(uri, cancellationToken);
    }
}
```

`Get()` lazily creates the client and reuses it for the registered service lifetime. The client has no base address or site-specific headers, so pass an absolute URI and configure each request as needed.

Let the dependency-injection container dispose `IHtmlClient`. If you construct it yourself, dispose the wrapper rather than the returned `HttpClient`.
