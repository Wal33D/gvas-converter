using System.IO;
using GvasFormat.Serialization.UETypes;
using GvasFormat.Serialization;

namespace GvasFormat.Tests;

public class UEEnumPropertyTests
{
    [Fact]
    public void ReadsValue()
    {
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, System.Text.Encoding.UTF8, true))
        {
            writer.WriteUEString("Color");
            writer.Write((byte)0);
            writer.WriteUEString("Red");
        }
        ms.Position = 0;
        using var reader = new BinaryReader(ms);
        var prop = new UEEnumProperty(reader, 0);
        Assert.Equal("Color", prop.EnumType);
        Assert.Equal("Red", prop.Value);
    }
}
