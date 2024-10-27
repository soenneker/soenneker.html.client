using Soenneker.Html.Client.Abstract;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.Html.Client;

/// <inheritdoc cref="IHtmlClient"/>
public class HtmlClient: IHtmlClient
{
    private readonly IHttpClientCache _httpClientCache;

    public HtmlClient(IHttpClientCache httpClientCache)
    {
        _httpClientCache = httpClientCache;
    }

    public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default)
    {
        return _httpClientCache.Get(nameof(HtmlClient), cancellationToken: cancellationToken);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        _httpClientCache.RemoveSync(nameof(HtmlClient));
    }

    public ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);

        return _httpClientCache.Remove(nameof(HtmlClient));
    }
}
