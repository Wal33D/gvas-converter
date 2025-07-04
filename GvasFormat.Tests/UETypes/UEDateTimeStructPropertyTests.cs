using System;
using System.IO;
using System.Text;
using GvasFormat.Serialization.UETypes;

namespace GvasFormat.Tests.UETypes;

public class UEDateTimeStructPropertyTests
{
    [Fact]
    public void Read_Minimal()
    {
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, Encoding.UTF8, leaveOpen: true))
            writer.Write(0L);

        ms.Position = 0;
        using var reader = new BinaryReader(ms, Encoding.UTF8, leaveOpen: true);
        var prop = new UEDateTimeStructProperty(reader);
        Assert.Equal(DateTime.FromBinary(0L), prop.Value);
    }
}
