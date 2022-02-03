using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherArchives
{

    internal static class ForecastLists
    {
        internal static List<ForecastElement> forecastDaysInput = new List<ForecastElement>();
        internal static List<ForecastElement> forecastTypesInput = new List<ForecastElement>();
        internal static List<ForecastElement> forecastHoursInput = new List<ForecastElement>();


        internal static List<ForecastElement> forecastDayList = new List<ForecastElement>
            {
                 new ForecastElement("1", "cr/", "Today"),
                 new ForecastElement("2","crdl/","Tomorrow"),
                 new ForecastElement("3","crdl1/","Day After Tomorrow")
            };

        internal static List<ForecastElement> forecastTypeList = new List<ForecastElement>
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
       internal static List<ForecastElement> HourList()
        {
         List<ForecastElement> forecastHourList = new List<ForecastElement>();

                for (int hour = 1; hour< 25; hour++)
                {
                    var stringifiedHour = hour.ToString();
        forecastHourList.Add(new ForecastElement(stringifiedHour, stringifiedHour, stringifiedHour));
                }
                return forecastHourList;
        }
}
}
