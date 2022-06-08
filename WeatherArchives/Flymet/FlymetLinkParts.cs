using System.Collections.Generic;

namespace Flymet
{

    public static class FlymetLinkParts
    {
        public static List<string> completeUrls = new List<string>();


        public static List<ForecastUrlElement> forecastRegions = new List<ForecastUrlElement>
            {
                 new ForecastUrlElement("1", "cr/", "Czech Republic today"),
                 new ForecastUrlElement("2","crdl/","Czech Republic tomorrow"),
                 new ForecastUrlElement("3","pomezi/","Czech-Slovak border today"),
                 new ForecastUrlElement("4","pomezidl/","Czech-Slovak border tomorrow"),
                 new ForecastUrlElement("5","sk/","Slovakia today"),
                 new ForecastUrlElement("6","skdl/","Slovakia tomorrow"),
                 new ForecastUrlElement("7","stev4d/","Europe today")
            };

        public static List<ForecastUrlElement> forecastProducts = new List<ForecastUrlElement>
            {
                new ForecastUrlElement("1","oblcH","High clouds"),
                new ForecastUrlElement("2","oblcM","Medium clouds"),
                new ForecastUrlElement("3","oblcL","Low clouds"),
                new ForecastUrlElement("4","oblcX","All clouds"),
                new ForecastUrlElement("5","vis","Visibility"),
                new ForecastUrlElement("6","srzk","Precipitation"),
                new ForecastUrlElement("7","t2m","Temperature"),
                new ForecastUrlElement("8","vitrx","Wind 10m"),
                new ForecastUrlElement("9","vitry","Gust"),
                new ForecastUrlElement("10","vitra","Wind 850 hPa"),
                new ForecastUrlElement("11","vitrb","Wind 800 hPa"),
                new ForecastUrlElement("12","vitrc","Wind 700 hPa"),
                new ForecastUrlElement("13","vitrd","Wind 600 hPa"),
                new ForecastUrlElement("14","vitre","Wind 500 hPa"),
                new ForecastUrlElement("15","drtr","kind of thermals"),
                new ForecastUrlElement("16","cudf","Convective temperature deficit"),
                new ForecastUrlElement("17","cukh","Cumulus clouds"),
                new ForecastUrlElement("18","cuvi","Wind speed below cloud base"),
                new ForecastUrlElement("19","cuvl","Humidity above cloud base"),
                new ForecastUrlElement("20","cuvr","Climb speed"),
                new ForecastUrlElement("21","cupot","Cumulus clouds simplified"),
                new ForecastUrlElement("22","curya","Climb speed 1000m"),
                new ForecastUrlElement("23","curyb","Climb speed 1500m"),
                new ForecastUrlElement("24","curyc","Climb speed 2000m"),
                new ForecastUrlElement("25","curyd","Climb speed 2500m"),
                new ForecastUrlElement("26","curye","Climb speed 3000m"),
                new ForecastUrlElement("27","curyf","Climb speed 3500m")
             };
        public static List<ForecastUrlElement> ForecastTimes()
        {
            List<ForecastUrlElement> forecastHourList = new List<ForecastUrlElement>();

            for (int hour = 1; hour < 25; hour++)
            {
                var stringifiedHour = hour.ToString();
                forecastHourList.Add(new ForecastUrlElement(stringifiedHour, stringifiedHour, stringifiedHour));
            }
            return forecastHourList;
        }
        public static List<WeatherForecastItem> GenerateWeatherForecasts(List<ForecastUrlElement> regionElement, List<ForecastUrlElement> productElement, List<ForecastUrlElement> timeElement)
        {
            var selectedForecastElements = new List<WeatherForecastItem>();

            foreach (var RegionInput in regionElement)
            {
                foreach (var ProductInput in productElement)
                {
                    foreach (var TimeInput in timeElement)
                    {
                        var forecastEntity = new WeatherForecastItem(RegionInput, ProductInput, TimeInput);
                        selectedForecastElements.Add(forecastEntity);
                    }
                }

            }
            return selectedForecastElements;

        }
    }
}
