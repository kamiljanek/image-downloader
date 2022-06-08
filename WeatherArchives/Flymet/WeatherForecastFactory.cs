using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flymet
{
    public class WeatherForecastFactory
    {
        public List<WeatherForecast> CreateWeatherForecasts(List<ForecastUrlElement> regionElement, List<ForecastUrlElement> productElement, List<ForecastUrlElement> timeElement)
        {
            var selectedForecastElements = new List<WeatherForecast>();

            foreach (var RegionInput in regionElement)
            {
                foreach (var ProductInput in productElement)
                {
                    foreach (var TimeInput in timeElement)
                    {
                        var forecastEntity = new WeatherForecast(RegionInput, ProductInput, TimeInput);
                        selectedForecastElements.Add(forecastEntity);
                    }
                }
            }
            return selectedForecastElements;
        }
    }
}
