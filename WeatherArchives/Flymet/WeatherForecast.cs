﻿namespace Flymet
{
    public class WeatherForecast
    {
        public const string BaseUrl = "https://flymet.meteopress.cz/";
        public const string UrlExtencion = ".png";
        public ForecastElement ForecastDay { get; set; }
        public ForecastElement ForecastType { get; set; }
        public ForecastElement ForecastHour { get; set; }
        public WeatherForecast(ForecastElement forecastDay, ForecastElement forecastType, ForecastElement forecastHour)
        {
            ForecastDay = forecastDay;
            ForecastType = forecastType;
            ForecastHour = forecastHour;
        }
        public string GenerateUrl()
        {
            return $"{BaseUrl}{ForecastDay.Code}{ForecastType.Code}{ForecastHour.Code}{UrlExtencion}";
        }

    }
}
