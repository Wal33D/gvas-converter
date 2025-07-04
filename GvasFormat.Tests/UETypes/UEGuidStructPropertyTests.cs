using System;
using System.IO;
using System.Text;
using GvasFormat.Serialization.UETypes;

namespace GvasFormat.Tests.UETypes;

public class UEGuidStructPropertyTests
{
    [Fact]
    public void Read_Basic()
    {
        var guid = Guid.NewGuid();
        using var ms = new MemoryStream(guid.ToByteArray());
        using var reader = new BinaryReader(ms, Encoding.UTF8, leaveOpen: true);
        var prop = new UEGuidStructProperty(reader);
        Assert.Equal(guid, prop.Value);
    }
}
