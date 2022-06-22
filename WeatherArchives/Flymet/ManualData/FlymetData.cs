using Flymet.Entities;
using System.Collections.Generic;

namespace Flymet.ManualData
{

    public class FlymetData
    {
        public static readonly List<FlymetUrlElement> forecastRegions = new List<FlymetUrlElement>
            {
                 new FlymetUrlElement("1", "cr/", "Czech Republic today"),
                 new FlymetUrlElement("2","crdl/","Czech Republic tomorrow"),
                 new FlymetUrlElement("3","pomezi/","Czech-Slovak border today"),
                 new FlymetUrlElement("4","pomezidl/","Czech-Slovak border tomorrow"),
                 new FlymetUrlElement("5","sk/","Slovakia today"),
                 new FlymetUrlElement("6","skdl/","Slovakia tomorrow"),
                 new FlymetUrlElement("7","stev4d/","Europe today")
            };

        public static readonly List<FlymetUrlElement> forecastProducts = new List<FlymetUrlElement>
            {
                new FlymetUrlElement("1","oblcH","High clouds"),
                new FlymetUrlElement("2","oblcM","Medium clouds"),
                new FlymetUrlElement("3","oblcL","Low clouds"),
                new FlymetUrlElement("4","oblcX","All clouds"),
                new FlymetUrlElement("5","vis","Visibility"),
                new FlymetUrlElement("6","srzk","Precipitation"),
                new FlymetUrlElement("7","t2m","Temperature"),
                new FlymetUrlElement("8","vitrx","Wind 10m"),
                new FlymetUrlElement("9","vitry","Gust"),
                new FlymetUrlElement("10","vitra","Wind 850 hPa"),
                new FlymetUrlElement("11","vitrb","Wind 800 hPa"),
                new FlymetUrlElement("12","vitrc","Wind 700 hPa"),
                new FlymetUrlElement("13","vitrd","Wind 600 hPa"),
                new FlymetUrlElement("14","vitre","Wind 500 hPa"),
                new FlymetUrlElement("15","drtr","kind of thermals"),
                new FlymetUrlElement("16","cudf","Convective temperature deficit"),
                new FlymetUrlElement("17","cukh","Cumulus clouds"),
                new FlymetUrlElement("18","cuvi","Wind speed below cloud base"),
                new FlymetUrlElement("19","cuvl","Humidity above cloud base"),
                new FlymetUrlElement("20","cuvr","Climb speed"),
                new FlymetUrlElement("21","cupot","Cumulus clouds simplified"),
                new FlymetUrlElement("22","curya","Climb speed 1000m"),
                new FlymetUrlElement("23","curyb","Climb speed 1500m"),
                new FlymetUrlElement("24","curyc","Climb speed 2000m"),
                new FlymetUrlElement("25","curyd","Climb speed 2500m"),
                new FlymetUrlElement("26","curye","Climb speed 3000m"),
                new FlymetUrlElement("27","curyf","Climb speed 3500m")
             };
        public static List<FlymetUrlElement> ForecastTimes()
        {
            List<FlymetUrlElement> forecastHourList = new List<FlymetUrlElement>();

            for (int hour = 1; hour < 25; hour++)
            {
                var stringifiedHour = hour.ToString();
                forecastHourList.Add(new FlymetUrlElement(stringifiedHour, stringifiedHour, stringifiedHour));
            }
            return forecastHourList;
        }
    }
}
