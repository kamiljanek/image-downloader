using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Engine
{
    public class FileSetting
    {
        //public void FileGenerator(string txtFilePath, List<ForecastElement> forecastElements)
        //{
        //    StreamWriter sw = File.CreateText(txtFilePath);
        //    foreach (var item in forecastElements)
        //    {
        //        sw.WriteLine($"{item.Id},{item.Code},{item.Name}");
        //    }
        //    sw.Close();
        //}
        //public void FileGenerator(string txtFilePath, string text)
        //{
        //    StreamWriter sw = File.CreateText(txtFilePath);
        //    sw.WriteLine($"{text}");
        //    sw.Close();
        //}
        public void FileGenerator(string jsonFilePath, object selectedItems)
        {
            var itemSerialized = JsonConvert.SerializeObject(selectedItems);
            File.WriteAllText(jsonFilePath, itemSerialized);
        }
        public List<T> FileReader<T>(string filePath)
        {
            var itemSerialized = File.ReadAllText(filePath);
            List<T> item = JsonConvert.DeserializeObject<List<T>>(itemSerialized);
        
            return item;
        }
        public List<ForecastElement> FileReader(string filePath, List<ForecastElement> forecastElements)
        {
            StreamReader sr = File.OpenText(filePath);
            string readedLine;
            while ((readedLine = sr.ReadLine()) != null)
            {
                string[] vs = readedLine.Split(',');
                forecastElements.Add(new ForecastElement(vs[0], vs[1], vs[2]));
            }
            sr.Close();
            return forecastElements;
        }
        //public List<string> FileReader(string filePath, List<string> textLines)
        //{
        //    StreamReader sr = File.OpenText(filePath);
        //    string readedLine;
        //    while ((readedLine = sr.ReadLine()) != null)
        //    {
        //        //string[] vs = readedLine.Split(',');
        //        textLines.Add(readedLine);
        //    }
        //    sr.Close();
        //    return textLines;
        //}
    }
}
