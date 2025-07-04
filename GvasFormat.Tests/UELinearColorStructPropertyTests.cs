using System.IO;
using GvasFormat.Serialization.UETypes;

namespace GvasFormat.Tests;

public class UELinearColorStructPropertyTests
{
    [Fact]
    public void ReadsValue()
    {
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, System.Text.Encoding.UTF8, true))
        {
            writer.Write(1f);
            writer.Write(2f);
            writer.Write(3f);
            writer.Write(4f);
        }
        ms.Position = 0;
        using var reader = new BinaryReader(ms);
        var prop = new UELinearColorStructProperty(reader);
        Assert.Equal(1f, prop.R);
        Assert.Equal(2f, prop.G);
        Assert.Equal(3f, prop.B);
        Assert.Equal(4f, prop.A);
    }
}
