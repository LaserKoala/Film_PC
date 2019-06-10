using FilmThicknessMeter.Utilites;
using System;
using System.Linq;
using System.Text;

namespace FilmThicknessMeter.Model
{
    public class Packet
    {
        public int DataSize = Int32.MinValue;
        public short MetaDataID = Int16.MinValue;
        public string Data = null;

        public Packet(byte[] data)
        {
            DataSize = ByteConverter.BytesToInt(data, 0, 4);
            MetaDataID = (short)ByteConverter.BytesToInt(data, 4, 2);
            Data = Encoding.ASCII.GetString(data.Skip(6).Take(DataSize-2).ToArray());
        }

        public Packet(short metaDataID, string data)
        {
            MetaDataID = metaDataID;
            Data = data;
        }

        public byte[] ToBytes()
        {
            var dataBytes = Encoding.ASCII.GetBytes(Data);
            var metaDataIDBytes = BitConverter.GetBytes(MetaDataID).Reverse();

            var bodyBytes = metaDataIDBytes.Concat(dataBytes).ToArray();
            return BitConverter.GetBytes(bodyBytes.Count())
                               .Reverse()
                               .Concat(bodyBytes)
                               .ToArray();
        }
    }
}
