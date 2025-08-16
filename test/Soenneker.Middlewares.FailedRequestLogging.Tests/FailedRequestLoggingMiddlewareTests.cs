using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Middlewares.FailedRequestLogging.Tests;

[Collection("Collection")]
public sealed class FailedRequestLoggingMiddlewareTests : FixturedUnitTest
{
    public FailedRequestLoggingMiddlewareTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {

    }
}
