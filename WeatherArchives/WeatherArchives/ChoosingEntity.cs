using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace WeatherArchives
{
    public class ChoosingEntity
    {
        public ChoosingEntity(string id, string code, string name)
        {
            Id = id;
            Code = code;
            Name = name;
            //weatherPropertiesListsss = new List<ChoosingProperties>();
        }
        //public List<ChoosingProperties> weatherPropertiesListsss { get; set; }
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    
        
    }
    
    public class WeatherForecastEntity
    {
        public WeatherForecastEntity(ChoosingEntity weatherDay, ChoosingEntity weatherType, ChoosingEntity weatherHour)
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
            return $"{localizationPath}\\{GenerateFileName()}"; //TODO need localization on Disc
        }
        public string GenerateFileName()
        {
            return string.Empty;
        }
        private const string BaseUrl = "https://flymet.meteopress.cz/";
        private const string UrlExtencion = ".png";
        public ChoosingEntity WeatherType { get; set; }
        public ChoosingEntity WeatherDay { get; set; }
        public ChoosingEntity WeatherHour { get; set; }

        internal void DownloadFile()
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFile(GenerateUrl(), GenerateFilePath());
        }
    }
    
}
