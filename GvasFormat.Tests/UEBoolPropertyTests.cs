using System.IO;
using GvasFormat.Serialization.UETypes;
using GvasFormat.Serialization;

namespace GvasFormat.Tests;

public class UEBoolPropertyTests
{
    [Fact]
    public void ReadsTrue()
    {
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, System.Text.Encoding.UTF8, true))
        {
            writer.Write((short)1);
        }
        ms.Position = 0;
        using var reader = new BinaryReader(ms);
        var prop = new UEBoolProperty(reader, 0);
        Assert.True(prop.Value);
    }
}
