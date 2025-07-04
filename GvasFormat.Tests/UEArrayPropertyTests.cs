using System.IO;
using GvasFormat.Serialization.UETypes;
using GvasFormat.Serialization;

namespace GvasFormat.Tests;

public class UEArrayPropertyTests
{
    [Fact]
    public void ReadsEmptyArray()
    {
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, System.Text.Encoding.UTF8, true))
        {
            writer.WriteUEString("IntProperty");
            writer.Write((byte)0);
            writer.Write(0); // count
        }
        ms.Position = 0;
        using var reader = new BinaryReader(ms);
        var prop = new UEArrayProperty(reader, 0);
        Assert.Equal("IntProperty", prop.ItemType);
        Assert.Empty(prop.Items);
    }
}
