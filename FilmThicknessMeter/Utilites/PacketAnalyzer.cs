using FilmThicknessMeter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmThicknessMeter.Utilites
{
    public static class PacketAnalyzer
    {
        public static void ParseMessage(Packet packet)
        {
            switch (packet.MetaDataID)
            {
                case 0:
                    {


                    }
                    break;

                case 1:
                    {


                    }
                    break;

                case 2:
                    {


                    }
                    break;

                case 3:
                    {
                        var splitData = packet.Data.Split('_');
                        var time = new DateTime() + TimeSpan.FromMilliseconds(Convert.ToDouble(splitData[0]));
                        var sensorID = Convert.ToUInt16(splitData[1]);
                        var value = Convert.ToDouble(splitData[2]);

                        ConnectionClient.SensorDataList.Add(new SensorData(time, sensorID, value));
                    }
                    break;
            }
        }
    }
        
}
