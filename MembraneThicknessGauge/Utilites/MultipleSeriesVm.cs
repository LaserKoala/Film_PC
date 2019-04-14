using System;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Geared;

namespace MembraneThicknessGauge.Utilites
{
    public class MultipleSeriesVm
    {
        public MultipleSeriesVm()
        {
            Series = new SeriesCollection();
            var r = new Random();

            for (var i = 0; i < 4; i++) // 30 series
            {
                var trend = 0d;
                var values = new double[100];

                for (var j = 0; j < 100; j++) // 10k points each
                {
                    trend += (r.NextDouble() < .8 ? 1 : -1) * r.Next(0, 10);
                    values[j] = trend;
                }

                var series = new GLineSeries
                {
                    Values = values.AsGearedValues().WithQuality(Quality.Low),
                    Fill = Brushes.Transparent,
                    StrokeThickness = .5,
                    PointGeometry = null //use a null geometry when you have many series
                };
                Series.Add(series);
            }
        }

        public SeriesCollection Series { get; set; }
    }
}
