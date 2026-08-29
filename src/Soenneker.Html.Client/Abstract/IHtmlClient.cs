using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Soenneker.Html.Client.Abstract;

/// <summary>
/// A .NET HTTP client for HTML parsing
/// </summary>
public interface IHtmlClient : IAsyncDisposable, IDisposable
{
    /// <summary>
    /// Returns the configured http Client used by the html client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested http Client.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
