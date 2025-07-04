using System;
using System.IO;
using GvasFormat.Serialization.UETypes;

namespace GvasFormat.Tests;

public class UEGuidStructPropertyTests
{
    [Fact]
    public void ReadsValue()
    {
        var guid = Guid.NewGuid();
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, System.Text.Encoding.UTF8, true))
        {
            writer.Write(guid.ToByteArray());
        }
        ms.Position = 0;
        using var reader = new BinaryReader(ms);
        var prop = new UEGuidStructProperty(reader);
        Assert.Equal(guid, prop.Value);
    }
}
