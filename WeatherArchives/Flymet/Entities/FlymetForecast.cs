using System.Collections.Generic;
using Model;

namespace Flymet
{
    public class FlymetForecast : IGenerate
    {
        private readonly string _name = "Flymet";
        public string Name => _name;
        public FlymetForecastUrlElement ForecastRegion { get; set; }
        public FlymetForecastUrlElement ForecastProduct { get; set; }
        public FlymetForecastUrlElement ForecastTime { get; set; }

        public FlymetForecast(FlymetForecastUrlElement forecastRegion, FlymetForecastUrlElement forecastProduct, FlymetForecastUrlElement forecastTime)
        {
            ForecastRegion = forecastRegion;
            ForecastProduct = forecastProduct;
            ForecastTime = forecastTime;
        }
        public string GenerateUrl()
        {
            return $"{FlymetConstValue.PageAdress}{ForecastRegion.Code}{ForecastProduct.Code}{ForecastTime.Code}{FlymetConstValue.UrlExtencion}";
        }
        public string GenerateFileName()
        {
            return $"{ForecastRegion.Name}-{ForecastProduct.Name}-{ForecastTime.Name}{FlymetConstValue.UrlExtencion}";
        }
  
    }
}
