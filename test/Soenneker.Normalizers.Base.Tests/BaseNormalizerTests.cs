using Soenneker.Normalizers.Base.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Normalizers.Base.Tests;

[Collection("Collection")]
public class BaseNormalizerTests : FixturedUnitTest
{

    public BaseNormalizerTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {

    }

    [Fact]
    public void Default()
    {

    }
}
