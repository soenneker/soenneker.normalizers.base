using Soenneker.Normalizers.Base.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Normalizers.Base.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class BaseNormalizerTests : HostedUnitTest
{

    public BaseNormalizerTests(Host host) : base(host)
    {

    }

    [Test]
    public void Default()
    {

    }
}
