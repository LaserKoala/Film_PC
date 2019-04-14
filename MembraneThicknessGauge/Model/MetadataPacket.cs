using MembraneThicknessGauge.Utilites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MembraneThicknessGauge.Model
{
    class MetadataPacket
    {
        public Int32 DataSize = Int32.MinValue;
        public Int32 MetaDataCount = Int32.MinValue;
        public List<string> Data = new List<string>(); 

        public MetadataPacket(byte[] data)
        {
            DataSize = ByteConverter.BytesToInt(data, 0, 4);
            MetaDataCount = ByteConverter.BytesToInt(data, 4, 4);
            var currentPosition = 8;
            for (var i = 0; i < MetaDataCount; i++)
            {
                var messageSize = ByteConverter.BytesToInt(data, currentPosition, 4);
                currentPosition += 4;
                var message = Encoding.ASCII.GetString(data.Skip(currentPosition)
                                                           .Take(messageSize)
                                                           .ToArray());
                Data.Add(message);
                currentPosition += messageSize;
            }
        }
    }
}
