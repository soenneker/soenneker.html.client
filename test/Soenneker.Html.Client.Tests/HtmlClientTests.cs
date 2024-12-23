using Soenneker.Html.Client.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Html.Client.Tests;

[Collection("Collection")]
public class HtmlClientTests : FixturedUnitTest
{
    private readonly IHtmlClient _util;

    public HtmlClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IHtmlClient>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
