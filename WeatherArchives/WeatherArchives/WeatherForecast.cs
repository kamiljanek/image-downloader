using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace WeatherArchives
{
    public class WeatherForecast
    {
        public WeatherForecast(ForecastElement forecastDay, ForecastElement forecastType, ForecastElement forecastHour)
        {
            ForecastDay = forecastDay;
            ForecastType = forecastType;
            ForecastHour = forecastHour;
        }
        private string localizationPath = @"C:\Users\JoHaNek\Desktop\archiwum"; //TODO move to configuration file
        public string GenerateUrl()
        {
            return $"{BaseUrl}{ForecastType.Code}{ForecastDay.Code}{ForecastHour.Code}{UrlExtencion}";
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
        public ForecastElement ForecastDay { get; set; }
        public ForecastElement ForecastType { get; set; }
        public ForecastElement ForecastHour { get; set; }

        internal void DownloadFile()
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFile(GenerateUrl(), GenerateFilePath());
        }
    }
}
