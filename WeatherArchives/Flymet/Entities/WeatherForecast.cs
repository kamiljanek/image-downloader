using System.Collections.Generic;
using Helper;

namespace Flymet
{
    public class WeatherForecast : IGenerate
    {
        private readonly string _name = "Flymet";
        public string Name => _name;
        public ForecastUrlElement ForecastRegion { get; set; }
        public ForecastUrlElement ForecastProduct { get; set; }
        public ForecastUrlElement ForecastTime { get; set; }

        public WeatherForecast(ForecastUrlElement forecastRegion, ForecastUrlElement forecastProduct, ForecastUrlElement forecastTime)
        {
            ForecastRegion = forecastRegion;
            ForecastProduct = forecastProduct;
            ForecastTime = forecastTime;
        }
        public string GenerateUrl()
        {
            return $"{ConstantValue.pageAdress}{ForecastRegion.Code}{ForecastProduct.Code}{ForecastTime.Code}{ConstantValue.UrlExtencion}";
        }
        public string GenerateFileName()
        {
            return $"{ForecastRegion.Name}-{ForecastProduct.Name}-{ForecastTime.Name}{ConstantValue.UrlExtencion}";
        }
  
    }
}
