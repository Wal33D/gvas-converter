using System.IO;
using GvasFormat.Serialization.UETypes;

namespace GvasFormat.Tests;

public class UEInt64PropertyTests
{
    [Fact]
    public void ReadsValue()
    {
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, System.Text.Encoding.UTF8, true))
        {
            writer.Write((byte)0);
            writer.Write(1234567890123L);
        }
        ms.Position = 0;
        using var reader = new BinaryReader(ms);
        var prop = new UEInt64Property(reader, sizeof(long));
        Assert.Equal(1234567890123L, prop.Value);
    }
}
