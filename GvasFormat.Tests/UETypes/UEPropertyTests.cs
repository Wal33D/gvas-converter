using System.IO;
using System.Text;
using GvasFormat.Serialization;
using GvasFormat.Serialization.UETypes;

namespace GvasFormat.Tests.UETypes;

public class UEPropertyTests
{
    [Fact]
    public void Read_IntProperty()
    {
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, Encoding.UTF8, leaveOpen: true))
        {
            writer.WriteUEString("MyInt");
            writer.WriteUEString("IntProperty");
            writer.Write(4L);
            writer.Write((byte)0);
            writer.Write(123);
        }

        ms.Position = 0;
        using var reader = new BinaryReader(ms, Encoding.UTF8, leaveOpen: true);
        var prop = UEProperty.Read(reader);
        var intProp = Assert.IsType<UEIntProperty>(prop);
        Assert.Equal("MyInt", intProp.Name);
        Assert.Equal(123, intProp.Value);
    }

    [Fact]
    public void Read_Array_ByteProperty()
    {
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, Encoding.UTF8, leaveOpen: true))
        {
            writer.WriteUEString("Data");
            writer.WriteUEString("ByteProperty");
            writer.Write(0L);
            writer.Write(new byte[] { 0x11, 0x22, 0x33 });
        }

        ms.Position = 0;
        using var reader = new BinaryReader(ms, Encoding.UTF8, leaveOpen: true);
        var props = UEProperty.Read(reader, 3);
        var p = Assert.IsType<UEByteProperty>(Assert.Single(props));
        Assert.Equal("112233", ((UEByteProperty)p).Value);
    }
}
