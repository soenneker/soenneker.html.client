using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Html.Client.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Html.Client.Registrars;

/// <summary>
/// A .NET HTTP client for HTML parsing
/// </summary>
public static class HtmlClientRegistrar
{
    /// <summary>
    /// Adds <see cref="IHtmlClient"/> as a singleton service. <para/>
    /// </summary>
    public static void AddHtmlClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCache();
        services.TryAddSingleton<IHtmlClient, HtmlClient>();
    }

    /// <summary>
    /// Adds <see cref="IHtmlClient"/> as a scoped service. <para/>
    /// </summary>
    public static void AddHtmlClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCache();
        services.TryAddScoped<IHtmlClient, HtmlClient>();
    }
}
