using System.Collections.Generic;

namespace Flymet
{

    public class FlymetData
    {
        public static readonly List<FlymetForecastUrlElement> forecastRegions = new List<FlymetForecastUrlElement>
            {
                 new FlymetForecastUrlElement("1", "cr/", "Czech Republic today"),
                 new FlymetForecastUrlElement("2","crdl/","Czech Republic tomorrow"),
                 new FlymetForecastUrlElement("3","pomezi/","Czech-Slovak border today"),
                 new FlymetForecastUrlElement("4","pomezidl/","Czech-Slovak border tomorrow"),
                 new FlymetForecastUrlElement("5","sk/","Slovakia today"),
                 new FlymetForecastUrlElement("6","skdl/","Slovakia tomorrow"),
                 new FlymetForecastUrlElement("7","stev4d/","Europe today")
            };

        public static readonly List<FlymetForecastUrlElement> forecastProducts = new List<FlymetForecastUrlElement>
            {
                new FlymetForecastUrlElement("1","oblcH","High clouds"),
                new FlymetForecastUrlElement("2","oblcM","Medium clouds"),
                new FlymetForecastUrlElement("3","oblcL","Low clouds"),
                new FlymetForecastUrlElement("4","oblcX","All clouds"),
                new FlymetForecastUrlElement("5","vis","Visibility"),
                new FlymetForecastUrlElement("6","srzk","Precipitation"),
                new FlymetForecastUrlElement("7","t2m","Temperature"),
                new FlymetForecastUrlElement("8","vitrx","Wind 10m"),
                new FlymetForecastUrlElement("9","vitry","Gust"),
                new FlymetForecastUrlElement("10","vitra","Wind 850 hPa"),
                new FlymetForecastUrlElement("11","vitrb","Wind 800 hPa"),
                new FlymetForecastUrlElement("12","vitrc","Wind 700 hPa"),
                new FlymetForecastUrlElement("13","vitrd","Wind 600 hPa"),
                new FlymetForecastUrlElement("14","vitre","Wind 500 hPa"),
                new FlymetForecastUrlElement("15","drtr","kind of thermals"),
                new FlymetForecastUrlElement("16","cudf","Convective temperature deficit"),
                new FlymetForecastUrlElement("17","cukh","Cumulus clouds"),
                new FlymetForecastUrlElement("18","cuvi","Wind speed below cloud base"),
                new FlymetForecastUrlElement("19","cuvl","Humidity above cloud base"),
                new FlymetForecastUrlElement("20","cuvr","Climb speed"),
                new FlymetForecastUrlElement("21","cupot","Cumulus clouds simplified"),
                new FlymetForecastUrlElement("22","curya","Climb speed 1000m"),
                new FlymetForecastUrlElement("23","curyb","Climb speed 1500m"),
                new FlymetForecastUrlElement("24","curyc","Climb speed 2000m"),
                new FlymetForecastUrlElement("25","curyd","Climb speed 2500m"),
                new FlymetForecastUrlElement("26","curye","Climb speed 3000m"),
                new FlymetForecastUrlElement("27","curyf","Climb speed 3500m")
             };
        public static List<FlymetForecastUrlElement> ForecastTimes()
        {
            List<FlymetForecastUrlElement> forecastHourList = new List<FlymetForecastUrlElement>();

            for (int hour = 1; hour < 25; hour++)
            {
                var stringifiedHour = hour.ToString();
                forecastHourList.Add(new FlymetForecastUrlElement(stringifiedHour, stringifiedHour, stringifiedHour));
            }
            return forecastHourList;
        }
    }
}
