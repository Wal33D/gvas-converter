using System.IO;
using System.Text;
using GvasFormat.Serialization;
using GvasFormat.Serialization.UETypes;

namespace GvasFormat.Tests.UETypes;

public class UETextPropertyTests
{
    [Fact]
    public void Read_Basic()
    {
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, Encoding.UTF8, leaveOpen: true))
        {
            writer.Write((byte)0);
            writer.Write(0L);
            writer.Write((byte)0);
            writer.WriteUEString(null);
            writer.WriteUEString("hello");
        }

        ms.Position = 0;
        using var reader = new BinaryReader(ms, Encoding.UTF8, leaveOpen: true);
        var prop = new UETextProperty(reader, 0);
        Assert.Equal(0L, prop.Flags);
        Assert.Null(prop.Id);
        Assert.Equal("hello", prop.Value);
    }
}
