using System.IO;
using GvasFormat.Serialization.UETypes;

namespace GvasFormat.Tests;

public class UEBytePropertyTests
{
    [Fact]
    public void ReadsBytes()
    {
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, System.Text.Encoding.UTF8, true))
        {
            writer.Write((byte)0);       // terminator
            writer.Write(1);             // array length
            writer.Write((byte)0xAB);    // value
        }
        ms.Position = 0;
        using var reader = new BinaryReader(ms);
        var prop = UEByteProperty.Read(reader, 0);
        Assert.Equal("ab", prop.Value);
    }

    [Fact]
    public void SkipsNonZeroTerminators()
    {
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, System.Text.Encoding.UTF8, true))
        {
            writer.Write((byte)0x10);    // bad terminator
            writer.Write((byte)0x20);    // another bad terminator
            writer.Write((byte)0);       // correct terminator
            writer.Write(1);             // array length
            writer.Write((byte)0xCD);    // value
        }
        ms.Position = 0;
        using var reader = new BinaryReader(ms);
        var prop = UEByteProperty.Read(reader, 0);
        Assert.Equal("cd", prop.Value);
    }
}
