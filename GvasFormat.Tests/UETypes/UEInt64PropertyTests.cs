using System.IO;
using System.Text;
using GvasFormat.Serialization.UETypes;

namespace GvasFormat.Tests.UETypes;

public class UEInt64PropertyTests
{
    [Fact]
    public void Read_Basic()
    {
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, Encoding.UTF8, leaveOpen: true))
        {
            writer.Write((byte)0);
            writer.Write(123456789L);
        }

        ms.Position = 0;
        using var reader = new BinaryReader(ms, Encoding.UTF8, leaveOpen: true);
        var prop = new UEInt64Property(reader, 8);
        Assert.Equal(123456789L, prop.Value);
    }
}
