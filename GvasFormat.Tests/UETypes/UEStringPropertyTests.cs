using System.IO;
using System.Text;
using GvasFormat.Serialization;
using GvasFormat.Serialization.UETypes;

namespace GvasFormat.Tests.UETypes;

public class UEStringPropertyTests
{
    [Fact]
    public void Read_EmptyString()
    {
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, Encoding.UTF8, leaveOpen: true))
        {
            writer.Write((byte)0);
            writer.WriteUEString(string.Empty);
        }

        ms.Position = 0;
        using var reader = new BinaryReader(ms, Encoding.UTF8, leaveOpen: true);
        var prop = new UEStringProperty(reader, 6);
        Assert.Equal(string.Empty, prop.Value);
    }
}
