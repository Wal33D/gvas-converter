using GvasFormat.Serialization.UETypes;

namespace GvasFormat.Tests;

public class UEGenericStructPropertyTests
{
    [Fact]
    public void StartsEmpty()
    {
        var prop = new UEGenericStructProperty();
        Assert.Empty(prop.Properties);
    }
}
