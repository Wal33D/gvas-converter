using System.IO;
using GvasFormat.Serialization.UETypes;
using GvasFormat.Serialization;

namespace GvasFormat.Tests;

public class UEMapPropertyTests
{
    [Fact]
    public void ReadsEmptyMap()
    {
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, System.Text.Encoding.UTF8, true))
        {
            writer.WriteUEString("IntProperty");
            writer.WriteUEString("IntProperty");
            writer.Write(new byte[5]);
            writer.Write(0); // count
        }
        ms.Position = 0;
        using var reader = new BinaryReader(ms);
        var prop = new UEMapProperty(reader, 0);
        Assert.Empty(prop.Map);
    }
}
