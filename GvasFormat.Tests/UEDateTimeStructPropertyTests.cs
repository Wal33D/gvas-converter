using System;
using System.IO;
using GvasFormat.Serialization.UETypes;

namespace GvasFormat.Tests;

public class UEDateTimeStructPropertyTests
{
    [Fact]
    public void ReadsValue()
    {
        var dt = DateTime.FromBinary(123456789);
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, System.Text.Encoding.UTF8, true))
        {
            writer.Write(dt.ToBinary());
        }
        ms.Position = 0;
        using var reader = new BinaryReader(ms);
        var prop = new UEDateTimeStructProperty(reader);
        Assert.Equal(dt, prop.Value);
    }
}
