using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flymet
{
    public class UserElement
    {
        public static List<ForecastUrlElement> forecastRegionsInput = new List<ForecastUrlElement>();
        public static List<ForecastUrlElement> forecastProductsInput = new List<ForecastUrlElement>();
        public static List<ForecastUrlElement> forecastTimesInput = new List<ForecastUrlElement>();
        public static List<WeatherForecastItem> selectedForecastElements = new List<WeatherForecastItem>();
        public static List<string> gmailInput = new List<string>();
    }
}
