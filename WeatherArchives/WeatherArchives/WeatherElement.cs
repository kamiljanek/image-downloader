using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace WeatherArchives
{
    public class WeatherElement
    {
        public WeatherElement(string id, string code, string name)
        {
            Id = id;
            Code = code;
            Name = name;
        }
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    
        
    }
    public class WeatherDay : WeatherElement
    {
        public WeatherDay(string id, string code, string name) : base (id, code, name)
        {

        }
    }
    public class WeatherType : WeatherElement
    {
        public WeatherType(string id, string code, string name) : base(id, code, name)
        {

        }
    }
    public class WeatherHour : WeatherElement
    {
        public WeatherHour(string id, string code, string name) : base(id, code, name)
        {

        }
    }
    public class WeatherForecast
    {
        public WeatherForecast(WeatherDay weatherDay, WeatherType weatherType, WeatherHour weatherHour)
        {
            WeatherType = weatherType;
            WeatherDay = weatherDay;
            WeatherHour = weatherHour;
        }
        private string localizationPath = @"C:\Users\JoHaNek\Desktop\archiwum"; //TODO move to configuration file
        public string GenerateUrl()
        {
            return $"{BaseUrl}{WeatherType.Code}{WeatherDay.Code}{WeatherHour.Code}{UrlExtencion}";
        }
        public string GenerateFilePath()
        {
            return $"{localizationPath}\\{GenerateFileName()}";
        }
        public string GenerateFileName()
        {
            return string.Empty;
        }
        private const string BaseUrl = "https://flymet.meteopress.cz/";
        private const string UrlExtencion = ".png";
        public WeatherDay WeatherDay { get; set; }
        public WeatherType WeatherType { get; set; }
        public WeatherHour WeatherHour { get; set; }

        internal void DownloadFile()
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFile(GenerateUrl(), GenerateFilePath());
        }
    }
    
}
