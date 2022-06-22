using System.Collections.Generic;
using Flymet.ManualData;
using Model;

namespace Flymet.Entities
{
    public class FlymetForecast : IGenerate
    {
        private readonly string _name = "Flymet";
        public string Name => _name;
        public FlymetUrlElement ForecastRegion { get; set; }
        public FlymetUrlElement ForecastProduct { get; set; }
        public FlymetUrlElement ForecastTime { get; set; }

        public FlymetForecast(FlymetUrlElement forecastRegion, FlymetUrlElement forecastProduct, FlymetUrlElement forecastTime)
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
