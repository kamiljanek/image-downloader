using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace WeatherArchives
{
    public class WeatherForecast
    {
        public WeatherForecast(ForecastDay weatherDay, ForecastType weatherType, ForecastTime weatherHour)
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
        public ForecastDay WeatherDay { get; set; }
        public ForecastType WeatherType { get; set; }
        public ForecastTime WeatherHour { get; set; }

        internal void DownloadFile()
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFile(GenerateUrl(), GenerateFilePath());
        }
    }
}
