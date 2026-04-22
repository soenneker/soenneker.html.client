using Soenneker.Html.Client.Abstract;
using Soenneker.Tests.HostedUnit;

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
}
