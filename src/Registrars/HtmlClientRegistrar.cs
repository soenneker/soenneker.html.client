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
    public static IServiceCollection AddHtmlClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton().TryAddSingleton<IHtmlClient, HtmlClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IHtmlClient"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddHtmlClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton().TryAddScoped<IHtmlClient, HtmlClient>();

        return services;
    }
}