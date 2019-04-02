using MembraneThicknessGauge.Code.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembraneThicknessGauge.Code
{
    class MetadataPacket
    {
        public Int32 DataSize = Int32.MinValue;
        public Int32 MetaDataID = Int32.MinValue;
        public List<string> Data = new List<string>(); 

        public MetadataPacket(byte[] data)
        {
            foreach (var iterByte in data)
            {
                Console.Write($"{iterByte} ");
            }
            Console.WriteLine();


            DataSize = ByteConverter.BytesToInt(data, 0, 4);
            MetaDataID = ByteConverter.BytesToInt(data, 4, 4);
            Console.WriteLine($"Size = {DataSize}");

            var currentPosition = 8;
            for (var i = 0; i < 4; i++)
            {
                var messageSize = ByteConverter.BytesToInt(data, currentPosition, 4);
                currentPosition += 4;

                var message = Encoding.ASCII.GetString(data.Skip(currentPosition)
                                                           .Take(messageSize)
                                                           .ToArray());
                Console.WriteLine(message);
                Data.Add(message);
                currentPosition += messageSize;
                Console.WriteLine(currentPosition);
            }
        }
    }
}
