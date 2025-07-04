using System.IO;
using GvasFormat.Serialization.UETypes;

namespace GvasFormat.Tests;

public class UEVectorStructPropertyTests
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
        }
        ms.Position = 0;
        using var reader = new BinaryReader(ms);
        var prop = new UEVectorStructProperty(reader);
        Assert.Equal(1f, prop.X);
        Assert.Equal(2f, prop.Y);
        Assert.Equal(3f, prop.Z);
    }
}
