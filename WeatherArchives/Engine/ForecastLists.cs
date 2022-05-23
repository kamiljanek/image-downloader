using System.Collections.Generic;

namespace Engine
{

    public static class ForecastLists
    {
        public static List<ForecastElement> forecastDaysInput = new List<ForecastElement>();
        public static List<ForecastElement> forecastTypesInput = new List<ForecastElement>();
        public static List<ForecastElement> forecastHoursInput = new List<ForecastElement>();
        public static List<WeatherForecast> selectedForecastElements = new List<WeatherForecast>();
        public static List<string> completeURLList = new List<string>();


        public static List<ForecastElement> forecastLocationsList = new List<ForecastElement>
            {
                 new ForecastElement("1", "cr/", "Czech Republic today"),
                 new ForecastElement("2","crdl/","Czech Republic tomorrow"),
                 new ForecastElement("3","pomezi/","Czech-Slovak border today"),
                 new ForecastElement("4","pomezidl/","Czech-Slovak border tomorrow"),
                 new ForecastElement("5","sk/","Slovakia today"),
                 new ForecastElement("6","skdl/","Slovakia tomorrow"),
                 new ForecastElement("7","stev4d/","Europe today")
            };

        public static List<ForecastElement> forecastProductsList = new List<ForecastElement>
            {
                new ForecastElement("1","oblcH","High clouds"),
                new ForecastElement("2","oblcM","Medium clouds"),
                new ForecastElement("3","oblcL","Low clouds"),
                new ForecastElement("4","oblcX","All clouds"),
                new ForecastElement("5","vis","Visibility"),
                new ForecastElement("6","srzk","Precipitation"),
                new ForecastElement("7","t2m","Temperature"),
                new ForecastElement("8","vitrx","Wind 10m"),
                new ForecastElement("9","vitry","Gust"),
                new ForecastElement("10","vitra","Wind 850 hPa"),
                new ForecastElement("11","vitrb","Wind 800 hPa"),
                new ForecastElement("12","vitrc","Wind 700 hPa"),
                new ForecastElement("13","vitrd","Wind 600 hPa"),
                new ForecastElement("14","vitre","Wind 500 hPa"),
                new ForecastElement("15","drtr","kind of thermals"),
                new ForecastElement("16","cudf","Convective temperature deficit"),
                new ForecastElement("17","cukh","Cumulus clouds"),
                new ForecastElement("18","cuvi","Wind speed below cloud base"),
                new ForecastElement("19","cuvl","Humidity above cloud base"),
                new ForecastElement("20","cuvr","Climb speed"),
                new ForecastElement("21","cupot","Cumulus clouds simplified"),
                new ForecastElement("22","curya","Climb speed 1000m"),
                new ForecastElement("23","curyb","Climb speed 1500m"),
                new ForecastElement("24","curyc","Climb speed 2000m"),
                new ForecastElement("25","curyd","Climb speed 2500m"),
                new ForecastElement("26","curye","Climb speed 3000m"),
                new ForecastElement("27","curyf","Climb speed 3500m")
             };
        public static List<ForecastElement> ForecastTimesList()
        {
            List<ForecastElement> forecastHourList = new List<ForecastElement>();

            for (int hour = 1; hour < 25; hour++)
            {
                var stringifiedHour = hour.ToString();
                forecastHourList.Add(new ForecastElement(stringifiedHour, stringifiedHour, stringifiedHour));
            }
            return forecastHourList;
        }
        public static List<WeatherForecast> GenerateDownloadItems(List<ForecastElement> dayElement, List<ForecastElement> typeElement, List<ForecastElement> hourElement)
        {
            var selectedForecastElements = new List<WeatherForecast>();

            foreach (var DayInput in dayElement)
            {
                foreach (var TypeInput in typeElement)
                {
                    foreach (var HourInput in hourElement)
                    {
                        var forecastEntity = new WeatherForecast(DayInput, TypeInput, HourInput);
                        selectedForecastElements.Add(forecastEntity);
                    }
                }

            }
            return selectedForecastElements;

        }
    }
}
