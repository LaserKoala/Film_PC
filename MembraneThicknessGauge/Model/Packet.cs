using MembraneThicknessGauge.Utilites;
using System;
using System.Linq;
using System.Text;

namespace MembraneThicknessGauge.Model
{
    class Packet
    {
        public int DataSize = Int32.MinValue;
        public int MetaDataID = Int32.MinValue;
        public String Data = null;

        public Packet(byte[] data)
        {
            DataSize = ByteConverter.BytesToInt(data, 0, 4);
            MetaDataID = ByteConverter.BytesToInt(data, 4, 2);
            Data = Encoding.ASCII.GetString(data.Skip(6).Take(DataSize-2).ToArray());
        }
    }
}
