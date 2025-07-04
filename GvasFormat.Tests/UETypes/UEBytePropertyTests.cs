using System.IO;
using System.Text;
using GvasFormat.Serialization.UETypes;

namespace GvasFormat.Tests.UETypes;

public class UEBytePropertyTests
{
    [Fact]
    public void Read_NonZeroTerminatorSkipped()
    {
        using var ms = new MemoryStream(new byte[] { 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00 });
        using var reader = new BinaryReader(ms, Encoding.UTF8, leaveOpen: true);
        var prop = UEByteProperty.Read(reader, 0);
        Assert.Equal(string.Empty, prop.Value);
    }

    [Fact]
    public void Read_WithCount()
    {
        using var ms = new MemoryStream(new byte[] { 0x11, 0x22, 0x33 });
        using var reader = new BinaryReader(ms, Encoding.UTF8, leaveOpen: true);
        var props = UEByteProperty.Read(reader, 0, 3);
        var p = Assert.IsType<UEByteProperty>(Assert.Single(props));
        Assert.Equal("112233", p.Value);
    }
}
