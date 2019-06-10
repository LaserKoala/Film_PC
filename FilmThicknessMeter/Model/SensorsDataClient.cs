using FilmThicknessMeter.Utilites;
using LiveCharts;
using LiveCharts.Configurations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmThicknessMeter.Model
{
    public class SensorsDataClient
    {
        public ChartValues<SensorData> FirstSensor = new ChartValues<SensorData>();
        public ChartValues<SensorData> SecondSensor = new ChartValues<SensorData>();
        public ChartValues<SensorData> ThirdSensor = new ChartValues<SensorData>();
        public ChartValues<SensorData> FourthSensor = new ChartValues<SensorData>();

        public SensorsDataClient()
        {
            var mapper = Mappers.Xy<SensorData>()
                 .X(model => model.Time)   //use DateTime.Ticks as X
                 .Y(model => model.Value);           //use the value property as Y
            Charting.For<SensorData>(mapper);
        }


        public void Add (SensorData data)
        {
            switch (data.SensorID)
            {
                case 0:
                    {
                        FirstSensor.Add(data);
                    }
                    break;

                case 1:
                    {
                        SecondSensor.Add(data);
                    }
                    break;

                case 2:
                    {
                        ThirdSensor.Add(data);
                    }
                    break;

                case 3:
                    {
                        FourthSensor.Add(data);
                    }
                    break;
            }
        }

        public void Clear()
        {
            FirstSensor.Clear();
            SecondSensor.Clear();
            ThirdSensor.Clear();
            FourthSensor.Clear();
        }
    }
}
