using System.IO;
using System.Text;
using GvasFormat.Serialization.UETypes;

namespace GvasFormat.Tests.UETypes;

public class UELinearColorStructPropertyTests
{
    [Fact]
    public void Read_Basic()
    {
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, Encoding.UTF8, leaveOpen: true))
        {
            writer.Write(1f);
            writer.Write(2f);
            writer.Write(3f);
            writer.Write(4f);
        }

        ms.Position = 0;
        using var reader = new BinaryReader(ms, Encoding.UTF8, leaveOpen: true);
        var prop = new UELinearColorStructProperty(reader);
        Assert.Equal(1f, prop.R);
        Assert.Equal(2f, prop.G);
        Assert.Equal(3f, prop.B);
        Assert.Equal(4f, prop.A);
    }
}
