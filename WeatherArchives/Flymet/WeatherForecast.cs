namespace Flymet
{
    public class WeatherForecast
    {
        public const string BaseUrl = Values.pageAdress;
        public const string UrlExtencion = ".png";
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
            return $"{BaseUrl}{ForecastRegion.Code}{ForecastProduct.Code}{ForecastTime.Code}{UrlExtencion}";
        }

    }
}
