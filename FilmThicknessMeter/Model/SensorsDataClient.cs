using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmThicknessMeter.Model
{
    class SensorsDataClient
    {
        private readonly IList<SensorData> _sensorsData = new List<SensorData>();

        public void Add (SensorData data)
        {
            _sensorsData.Add(data);
        }

        public void Remove(SensorData removeData)
        {
            foreach(var data in _sensorsData)
            {
                if((removeData.SensorID == data.SensorID)&&
                    (removeData.Time == data.Time)&&
                    (removeData.Value == data.Value))
                {
                    _sensorsData.Remove(data);
                }
            }
        }
    }
}
