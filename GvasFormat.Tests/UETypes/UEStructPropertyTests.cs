using System.IO;
using System.Text;
using GvasFormat.Serialization;
using GvasFormat.Serialization.UETypes;

namespace GvasFormat.Tests.UETypes;

public class UEStructPropertyTests
{
    [Fact]
    public void Read_VectorStruct()
    {
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, Encoding.UTF8, leaveOpen: true))
        {
            writer.WriteUEString("Vector");
            writer.Write(System.Guid.Empty.ToByteArray());
            writer.Write((byte)0);
            writer.Write(1f);
            writer.Write(2f);
            writer.Write(3f);
        }

        ms.Position = 0;
        using var reader = new BinaryReader(ms, Encoding.UTF8, leaveOpen: true);
        var prop = UEStructProperty.Read(reader, 12);
        var vector = Assert.IsType<UEVectorStructProperty>(prop);
        Assert.Equal(1f, vector.X);
        Assert.Equal(2f, vector.Y);
        Assert.Equal(3f, vector.Z);
    }
}
