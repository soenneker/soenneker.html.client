using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Soenneker.Html.Client.Abstract;

/// <summary>
/// Provides a cached <see cref="HttpClient"/> for retrieving HTML resources.
/// </summary>
public interface IHtmlClient : IAsyncDisposable, IDisposable
{
    /// <summary>
    /// Gets the HTTP client cached for this service's lifetime.
    /// </summary>
    /// <param name="cancellationToken">Stops client creation if the cached instance has not been created yet.</param>
    /// <returns>The cached HTTP client.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
