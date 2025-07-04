using System.IO;
using System.Text;
using GvasFormat.Serialization;
using GvasFormat.Serialization.UETypes;

namespace GvasFormat.Tests.UETypes;

public class UEEnumPropertyTests
{
    [Fact]
    public void Read_Basic()
    {
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, Encoding.UTF8, leaveOpen: true))
        {
            writer.WriteUEString("SomeEnum");
            writer.Write((byte)0);
            writer.WriteUEString("ValueA");
        }

        ms.Position = 0;
        using var reader = new BinaryReader(ms, Encoding.UTF8, leaveOpen: true);
        var prop = new UEEnumProperty(reader, 0);
        Assert.Equal("SomeEnum", prop.EnumType);
        Assert.Equal("ValueA", prop.Value);
    }
}
