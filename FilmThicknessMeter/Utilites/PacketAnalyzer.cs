using FilmThicknessMeter.Model;
using FilmThicknessMeter.ViewModels;
using System;

namespace FilmThicknessMeter.Utilites
{
    public static class PacketAnalyzer
    {
        public static void ParseMessage(Packet packet, MainViewModel viewModel)
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
                        var sensorID = Convert.ToUInt16(splitData[0]);
                        var time =  Convert.ToUInt64(splitData[1]);
                        var value = Convert.ToDouble(splitData[2]);

                        viewModel.SensorsDataClient.Add(new SensorData(time, sensorID, value));
                    }
                    break;
            }
        }
    }
        
}
