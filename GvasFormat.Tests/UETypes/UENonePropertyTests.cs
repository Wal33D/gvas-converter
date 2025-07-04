using System.IO;
using System.Text;
using GvasFormat.Serialization;
using GvasFormat.Serialization.UETypes;

namespace GvasFormat.Tests.UETypes;

public class UENonePropertyTests
{
    [Fact]
    public void Read_WithUEProperty()
    {
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, Encoding.UTF8, leaveOpen: true))
            writer.WriteUEString("None");

        ms.Position = 0;
        using var reader = new BinaryReader(ms, Encoding.UTF8, leaveOpen: true);
        var prop = UEProperty.Read(reader);
        var none = Assert.IsType<UENoneProperty>(prop);
        Assert.Equal("None", none.Name);
    }
}
