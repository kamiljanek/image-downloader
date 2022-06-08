namespace Flymet
{
    public class WeatherForecastItem
    {
        public const string BaseUrl = Values.pageAdress;
        public const string UrlExtencion = ".png";
        public ForecastUrlElement ForecastRegion { get; set; }
        public ForecastUrlElement ForecastProduct { get; set; }
        public ForecastUrlElement ForecastTime { get; set; }
        public WeatherForecastItem(ForecastUrlElement forecastRegion, ForecastUrlElement forecastProduct, ForecastUrlElement forecastTime)
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
