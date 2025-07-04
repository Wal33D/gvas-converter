using System.IO;
using GvasFormat.Serialization.UETypes;
using GvasFormat.Serialization;

namespace GvasFormat.Tests;

public class UEStringPropertyTests
{
    [Fact]
    public void ReadsValue()
    {
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, System.Text.Encoding.UTF8, true))
        {
            writer.Write((byte)0);
            writer.WriteUEString("hello");
        }
        ms.Position = 0;
        using var reader = new BinaryReader(ms);
        var prop = new UEStringProperty(reader, 0);
        Assert.Equal("hello", prop.Value);
    }
}
