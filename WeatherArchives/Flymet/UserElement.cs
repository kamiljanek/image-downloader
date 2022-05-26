using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flymet
{
    public class UserElement
    {
        public static List<ForecastElement> forecastDaysInput = new List<ForecastElement>();
        public static List<ForecastElement> forecastTypesInput = new List<ForecastElement>();
        public static List<ForecastElement> forecastHoursInput = new List<ForecastElement>();
        public static List<WeatherForecast> selectedForecastElements = new List<WeatherForecast>();
        public static List<string> gmailInput = new List<string>();
    }
}
