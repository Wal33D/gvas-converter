using System.IO;
using System.Text;
using GvasFormat.Serialization.UETypes;

namespace GvasFormat.Tests.UETypes;

public class UEInt8PropertyTests
{
    [Fact]
    public void Read_Basic()
    {
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, Encoding.UTF8, leaveOpen: true))
        {
            writer.Write((byte)0);
            writer.Write((sbyte)-5);
        }

        ms.Position = 0;
        using var reader = new BinaryReader(ms, Encoding.UTF8, leaveOpen: true);
        var prop = new UEInt8Property(reader, 1);
        Assert.Equal((sbyte)-5, prop.Value);
    }
}
