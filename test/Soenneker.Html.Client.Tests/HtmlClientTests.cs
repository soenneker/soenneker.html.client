using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Soenneker.Html.Client.Abstract;
using Soenneker.Html.Client.Registrars;
using Soenneker.Tests.HostedUnit;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.Html.Client.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class HtmlClientTests : HostedUnitTest
{
    private readonly IHtmlClient _util;

    public HtmlClientTests(Host host) : base(host)
    {
        _util = Resolve<IHtmlClient>(true);
    }

    [Test]
    public void Default()
    {

    }

    [Test]
    public async Task Scoped_client_uses_scoped_cache()
    {
        var services = new ServiceCollection();

        services.AddHtmlClientAsScoped();

        ServiceDescriptor cache = services.Single(descriptor => descriptor.ServiceType == typeof(IHttpClientCache));
        ServiceDescriptor client = services.Single(descriptor => descriptor.ServiceType == typeof(IHtmlClient));

        await Assert.That(cache.Lifetime).IsEqualTo(ServiceLifetime.Scoped);
        await Assert.That(client.Lifetime).IsEqualTo(ServiceLifetime.Scoped);
    }

    [Test]
    public async Task Singleton_client_uses_singleton_cache()
    {
        var services = new ServiceCollection();

        services.AddHtmlClientAsSingleton();

        ServiceDescriptor cache = services.Single(descriptor => descriptor.ServiceType == typeof(IHttpClientCache));
        ServiceDescriptor client = services.Single(descriptor => descriptor.ServiceType == typeof(IHtmlClient));

        await Assert.That(cache.Lifetime).IsEqualTo(ServiceLifetime.Singleton);
        await Assert.That(client.Lifetime).IsEqualTo(ServiceLifetime.Singleton);
    }
}
