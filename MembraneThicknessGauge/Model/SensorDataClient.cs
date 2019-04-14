using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembraneThicknessGauge.Model
{
    class SensorDataClient
    {
        private IDictionary<long, SensorData> TimeData = new Dictionary<long, SensorData>();
    }

    public struct SensorData
    {
        public int sensorID;
        public double value;
    }
}
