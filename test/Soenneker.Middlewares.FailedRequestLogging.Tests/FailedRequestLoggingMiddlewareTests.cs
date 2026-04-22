using Soenneker.Tests.HostedUnit;

namespace Soenneker.Middlewares.FailedRequestLogging.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class FailedRequestLoggingMiddlewareTests : HostedUnitTest
{
    public FailedRequestLoggingMiddlewareTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
