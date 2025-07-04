using System.IO;
using System.Text;
using GvasFormat.Serialization;
using GvasFormat.Serialization.UETypes;

namespace GvasFormat.Tests.UETypes;

public class UEMapPropertyTests
{
    [Fact]
    public void Read_EmptyMap()
    {
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, Encoding.UTF8, leaveOpen: true))
        {
            writer.WriteUEString("IntProperty");
            writer.WriteUEString("IntProperty");
            writer.Write(new byte[5]);
            writer.Write(0);
        }

        ms.Position = 0;
        using var reader = new BinaryReader(ms, Encoding.UTF8, leaveOpen: true);
        var prop = new UEMapProperty(reader, 0);
        Assert.Empty(prop.Map);
    }
}
