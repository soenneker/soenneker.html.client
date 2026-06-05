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
    /// Gets the value.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
