using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmThicknessMeter.Model
{
    public class SensorData
    {
        private DateTime _time;
        public DateTime Time
        {
            get
            {
                return _time;
            }
            private set
            {
                _time = value;
            }
        }

        private ushort _sensorID;
        public ushort SensorID
        {
            get
            {
                return _sensorID;
            }
            private set
            {
                _sensorID = value;
            }
        }

        private double _value;
        public double Value
        {
            get
            {
                return _value;
            }
            private set
            {
                _value = value;
            }
        }

        public SensorData(DateTime time, ushort sensorID, double value)
        {
            Time = time;
            SensorID = sensorID;
            Value = value;
        }
    }
}
