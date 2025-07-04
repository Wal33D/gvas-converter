using System.IO;
using System.Text;
using GvasFormat.Serialization;
using GvasFormat.Serialization.UETypes;

namespace GvasFormat.Tests.UETypes;

public class UEGenericStructPropertyTests
{
    [Fact]
    public void Read_GenericStruct()
    {
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, Encoding.UTF8, leaveOpen: true))
        {
            writer.WriteUEString("UnknownType");
            writer.Write(System.Guid.Empty.ToByteArray());
            writer.Write((byte)0);
            writer.WriteUEString("None");
        }

        ms.Position = 0;
        using var reader = new BinaryReader(ms, Encoding.UTF8, leaveOpen: true);
        var prop = UEStructProperty.Read(reader, 0);
        var generic = Assert.IsType<UEGenericStructProperty>(prop);
        Assert.Single(generic.Properties);
        Assert.IsType<UENoneProperty>(generic.Properties[0]);
    }
}
