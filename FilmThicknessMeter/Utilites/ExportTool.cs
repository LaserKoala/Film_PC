using ClosedXML.Excel;
using FilmThicknessMeter.Model;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmThicknessMeter.Utilites
{
    public static class ExportTool
    {
        public static void SaveCSV(string path, List<SensorData> list)
        {
            var csv = new StringBuilder();

            foreach (var data in list)
            {
                var newLine = string.Format("{0},{1},{2}", data.Time, data.SensorID, data.Value);
                csv.AppendLine(newLine);
            }

            File.WriteAllText(path, csv.ToString());
        }

        public static void SaveJSON(string path, List<SensorData> list)
        {
            var json = JsonConvert.SerializeObject(list);
            File.WriteAllText(path, json);
        }

        public static void SaveXLSX(string path, List<SensorData> list)
        {
            var workbook = new XLWorkbook();
            workbook.AddWorksheet("SensorsData");
            var ws = workbook.Worksheet("SensorsData");

            int row = 1;
            ws.Cell("A" + row.ToString()).Value = "Время";
            ws.Cell("B" + row.ToString()).Value = "Датчик";
            ws.Cell("C" + row.ToString()).Value = "Значение";
            row++;

            foreach (SensorData item in list)
            {
                ws.Cell("A" + row.ToString()).Value = item.Time;
                ws.Cell("B" + row.ToString()).Value = item.SensorID;
                ws.Cell("C" + row.ToString()).Value = item.Value;
                row++;
            }
            Console.WriteLine(path);

            workbook.SaveAs(path);
        }
    }
}
