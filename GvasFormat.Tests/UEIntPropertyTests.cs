using System.IO;
using GvasFormat.Serialization.UETypes;

namespace GvasFormat.Tests;

public class UEIntPropertyTests
{
    [Fact]
    public void ReadsValue()
    {
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, System.Text.Encoding.UTF8, true))
        {
            writer.Write((byte)0); // terminator
            writer.Write(1234);
        }
        ms.Position = 0;
        using var reader = new BinaryReader(ms);
        var prop = new UEIntProperty(reader, sizeof(int));
        Assert.Equal(1234, prop.Value);
    }
}
