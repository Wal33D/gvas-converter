using System.IO;
using GvasFormat.Serialization.UETypes;

namespace GvasFormat.Tests;

public class UEInt8PropertyTests
{
    [Fact]
    public void ReadsValue()
    {
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, System.Text.Encoding.UTF8, true))
        {
            writer.Write((byte)0);
            writer.Write((sbyte)-5);
        }
        ms.Position = 0;
        using var reader = new BinaryReader(ms);
        var prop = new UEInt8Property(reader, sizeof(sbyte));
        Assert.Equal(-5, prop.Value);
    }
}
