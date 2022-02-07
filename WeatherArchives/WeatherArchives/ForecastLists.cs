using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherArchives
{

    public static class ForecastLists
    {
        public static List<ForecastElement> forecastDaysInput = new List<ForecastElement>();
        public static List<ForecastElement> forecastTypesInput = new List<ForecastElement>();
        public static List<ForecastElement> forecastHoursInput = new List<ForecastElement>();
        public static List<WeatherForecast> selectedForecastElements = new List<WeatherForecast>();
        public static List<string> completeURLList = new List<string>();


        internal static List<ForecastElement> forecastDaysList = new List<ForecastElement>
            {
                 new ForecastElement("1", "cr/", "Today"),
                 new ForecastElement("2","crdl/","Tomorrow"),
                 new ForecastElement("3","crdl1/","Day After Tomorrow")
            };

        internal static List<ForecastElement> forecastTypesList = new List<ForecastElement>
            {
                new ForecastElement("1","oblcX","All Clouds"),
                new ForecastElement("2","srzk","Precipitation"),
                new ForecastElement("3","t2m","Temperature"),
                new ForecastElement("4","vitrx","Wind 10m"),
                new ForecastElement("5","vitry","Gust"),
                new ForecastElement("6","vitra","Wind 850 hPa"),
                new ForecastElement("7","vitrb","Wind 800 hPa"),
                new ForecastElement("8","drtr","Kind of Thermals"),
                new ForecastElement("9","cudf","Convective Temperature Deficit"),
                new ForecastElement("10","cukh","Cumulus Clouds"),
                new ForecastElement("11","cuvr","Climb Speed")
             };
        internal static List<ForecastElement> HoursList()
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
        //public static List<string> GeneratorURLs(List<WeatherForecast> selectedForecastElements)
        //{
        //    var URLList = new List<string>();
        //    foreach (var item in selectedForecastElements)
        //    {
        //        URLList.Add(item.GenerateUrl());
        //    }
        //    return URLList;
        //}
    }
}
