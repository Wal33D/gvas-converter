using System;
using System.IO;
using GvasFormat.Serialization.UETypes;
using GvasFormat.Serialization;

namespace GvasFormat.Tests;

public class UEStructPropertyTests
{
    [Fact]
    public void ReadsDateTimeStruct()
    {
        var dt = DateTime.FromBinary(42);
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, System.Text.Encoding.UTF8, true))
        {
            writer.WriteUEString("DateTime");
            writer.Write(Guid.Empty.ToByteArray());
            writer.Write((byte)0);
            writer.Write(dt.ToBinary());
        }
        ms.Position = 0;
        using var reader = new BinaryReader(ms);
        var prop = UEStructProperty.Read(reader, 0) as UEDateTimeStructProperty;
        Assert.NotNull(prop);
        Assert.Equal(dt, prop.Value);
    }
}
