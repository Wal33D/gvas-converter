using System.IO;
using GvasFormat.Serialization.UETypes;
using GvasFormat.Serialization;

namespace GvasFormat.Tests;

public class UEPropertyTests
{
    [Fact]
    public void ReadsNone()
    {
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, System.Text.Encoding.UTF8, true))
        {
            writer.WriteUEString("None");
        }
        ms.Position = 0;
        using var reader = new BinaryReader(ms);
        var prop = UEProperty.Read(reader);
        Assert.IsType<UENoneProperty>(prop);
    }
}
