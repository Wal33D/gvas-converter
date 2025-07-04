using System.IO;
using GvasFormat.Serialization.UETypes;
using GvasFormat.Serialization;

namespace GvasFormat.Tests;

public class UETextPropertyTests
{
    [Fact]
    public void ReadsValue()
    {
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, System.Text.Encoding.UTF8, true))
        {
            writer.Write((byte)0);          // terminator
            writer.Write(0L);                // Flags
            writer.Write((byte)0);          // terminator
            writer.WriteUEString("id");
            writer.WriteUEString("text");
        }
        ms.Position = 0;
        using var reader = new BinaryReader(ms);
        var prop = new UETextProperty(reader, 0);
        Assert.Equal(0L, prop.Flags);
        Assert.Equal("id", prop.Id);
        Assert.Equal("text", prop.Value);
    }
}
