using System;
using GvasFormat.Utils;

namespace GvasFormat.Tests;

public class StringExTests
{
    [Fact]
    public void AsHex_AsBytes_RoundTrip()
    {
        var bytes = new byte[] { 0x00, 0x01, 0xAB, 0xFF };
        var hex = bytes.AsHex();
        var roundTrip = hex.AsBytes();
        Assert.Equal(bytes, roundTrip);
    }

    [Fact]
    public void AsBytes_AsHex_RoundTrip()
    {
        const string hex = "0a0b0c";
        var bytes = hex.AsBytes();
        var roundTrip = bytes.AsHex();
        Assert.Equal(hex, roundTrip);
    }

    [Fact]
    public void AsBytes_Throws_On_Odd_Length()
    {
        Assert.Throws<InvalidOperationException>(() => "abc".AsBytes());
    }
}
