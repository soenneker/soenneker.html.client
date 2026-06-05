using Soenneker.Html.Client.Abstract;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.Html.Client;

/// <inheritdoc cref="IHtmlClient"/>
public sealed class HtmlClient : IHtmlClient
{
    private readonly IHttpClientCache _httpClientCache;

    private const string _cacheKey = nameof(HtmlClient);

    public HtmlClient(IHttpClientCache httpClientCache)
    {
        _httpClientCache = httpClientCache;
    }

    public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default)
    {
        return _httpClientCache.Get(_cacheKey, cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Releases resources used by the current instance.
    /// </summary>
    public void Dispose()
    {
        _httpClientCache.RemoveSync(_cacheKey);
    }

    /// <summary>
    /// Asynchronously releases resources used by the current instance.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public ValueTask DisposeAsync()
    {
        return _httpClientCache.Remove(_cacheKey);
    }
}