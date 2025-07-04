using System.IO;
using System.Text;
using GvasFormat.Serialization;

namespace GvasFormat.Tests;

public class BinaryReaderExTests
{
    [Fact]
    public void WriteRead_NullString()
    {
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, Encoding.UTF8, leaveOpen: true))
            writer.WriteUEString(null);

        Assert.Equal(new byte[] { 0, 0, 0, 0 }, ms.ToArray());

        ms.Position = 0;
        using var reader = new BinaryReader(ms, Encoding.UTF8, leaveOpen: true);
        var value = reader.ReadUEString();
        Assert.Null(value);
    }

    [Fact]
    public void WriteRead_EmptyString()
    {
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, Encoding.UTF8, leaveOpen: true))
            writer.WriteUEString(string.Empty);

        Assert.Equal(new byte[] { 1, 0, 0, 0, 0 }, ms.ToArray());

        ms.Position = 0;
        using var reader = new BinaryReader(ms, Encoding.UTF8, leaveOpen: true);
        var value = reader.ReadUEString();
        Assert.Equal(string.Empty, value);
    }

    [Fact]
    public void WriteRead_TypicalString()
    {
        const string input = "Hello";
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, Encoding.UTF8, leaveOpen: true))
            writer.WriteUEString(input);

        ms.Position = 0;
        using var reader = new BinaryReader(ms, Encoding.UTF8, leaveOpen: true);
        var value = reader.ReadUEString();
        Assert.Equal(input, value);
    }
}
