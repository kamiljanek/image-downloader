using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WeatherArchives
{
    internal class Data
    {
        internal void FileGenerator(string txtFilePath, List<ForecastElement> forecastElements)
        {
            StreamWriter sw = File.CreateText(txtFilePath);
            foreach (var item in forecastElements)
            {
                sw.WriteLine($"{item.Id},{item.Code},{item.Name}");
            }
            sw.Close();
        }
        internal void FileGenerator(string txtFilePath, string text)
        {
            StreamWriter sw = File.CreateText(txtFilePath);
            sw.WriteLine($"{text}");
            sw.Close();
        }
    }
}
