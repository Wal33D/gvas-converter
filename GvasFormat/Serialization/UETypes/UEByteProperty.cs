using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using GvasFormat.Utils;

namespace GvasFormat.Serialization.UETypes
{
    [DebuggerDisplay("{Value}", Name = "{Name}")]
    public sealed class UEByteProperty : UEProperty
    {
        private static readonly Encoding Utf8 = new UTF8Encoding(false);

        public UEByteProperty() { }
        public static UEByteProperty Read(BinaryReader reader, long valueLength)
        {
            var terminator = reader.ReadByte();
            // Some games incorrectly store a non-zero value here. Skip any
            // non-zero bytes instead of failing the read.
            while (terminator != 0 && reader.BaseStream.Position < reader.BaseStream.Length)
                terminator = reader.ReadByte();

            // valueLength starts here
            var arrayLength = reader.ReadInt32();
            var bytes = reader.ReadBytes(arrayLength);
            return new UEByteProperty {Value = bytes.AsHex()};
        }

        public static UEProperty[] Read(BinaryReader reader, long valueLength, int count)
        {
            // valueLength starts here
            var bytes = reader.ReadBytes(count);
            return new UEProperty[]{ new UEByteProperty {Value = bytes.AsHex()}};
        }

        public override void Serialize(BinaryWriter writer) => throw new NotImplementedException();

        public string Value;
    }
}