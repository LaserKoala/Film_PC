using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembraneThicknessGauge.Code.Tools
{
    class ByteConverter
    {
        public static int BytesToInt(byte[] data, int skip, int take)
        {
            var bytes = data.Skip(skip).Take(take).Reverse().ToArray();

            return BitConverter.ToInt32(bytes, 0);
        }
    }
}
