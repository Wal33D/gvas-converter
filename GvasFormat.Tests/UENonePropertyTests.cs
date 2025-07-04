using GvasFormat.Serialization.UETypes;

namespace GvasFormat.Tests;

public class UENonePropertyTests
{
    [Fact]
    public void CanInstantiate()
    {
        var prop = new UENoneProperty();
        Assert.NotNull(prop);
    }
}
