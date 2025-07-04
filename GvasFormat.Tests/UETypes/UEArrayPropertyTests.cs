using System.IO;
using System.Text;
using GvasFormat.Serialization;
using GvasFormat.Serialization.UETypes;

namespace GvasFormat.Tests.UETypes;

public class UEArrayPropertyTests
{
    [Fact]
    public void Read_EmptyIntArray()
    {
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, Encoding.UTF8, leaveOpen: true))
        {
            writer.WriteUEString("IntProperty");
            writer.Write((byte)0);
            writer.Write(0);
        }

        ms.Position = 0;
        using var reader = new BinaryReader(ms, Encoding.UTF8, leaveOpen: true);
        var prop = new UEArrayProperty(reader, 4);
        Assert.Equal("IntProperty", prop.ItemType);
        Assert.Empty(prop.Items);
    }
}
