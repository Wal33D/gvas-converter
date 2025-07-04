using System.IO;
using GvasFormat.Serialization.UETypes;

namespace GvasFormat.Tests;

public class UEFloatPropertyTests
{
    [Fact]
    public void ReadsValue()
    {
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, System.Text.Encoding.UTF8, true))
        {
            writer.Write((byte)0);
            writer.Write(1.5f);
        }
        ms.Position = 0;
        using var reader = new BinaryReader(ms);
        var prop = new UEFloatProperty(reader, sizeof(float));
        Assert.Equal(1.5f, prop.Value);
    }
}
