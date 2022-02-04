using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherArchives
{
    public static class Values
    {
        public static string dbo_URLs = "URLs";
        public static string dbo_OwnersData = "OwnersData";
        internal const string MainMenuEnds = "to download...";
        internal const string appTitle = "WEATHER ARCHIVES";
        internal const string pageAdress = "http://flymet.meteopress.cz/";
        internal static string completeFolderPath;
        internal static void Title()
        {
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth - pageAdress.Length) / 2, Console.CursorTop); //centering text
            Console.WriteLine(pageAdress);

            Console.SetCursorPosition((Console.WindowWidth - appTitle.Length) / 2, Console.CursorTop); //centering text
            Console.WriteLine(appTitle);
            Console.WriteLine("");
        }
        static void StartDownload(List<WeatherForecast> selectedWeatherForcastList) //TODO export this method to other file
        {
            foreach (var val in selectedWeatherForcastList)
            {
                val.DownloadFile();
            }

        }
    }
}
