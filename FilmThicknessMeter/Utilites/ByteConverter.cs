using System;
using System.Linq;

namespace FilmThicknessMeter.Utilites
{
    class ByteConverter
    {
        public static int BytesToInt(byte[] data, int skip, int take)
        {
            var bytes = data.Skip(skip).Take(take).Reverse().ToArray();

            return take==4 ? BitConverter.ToInt32(bytes, 0) : BitConverter.ToInt16(bytes, 0);
        }
    }
}
