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
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
