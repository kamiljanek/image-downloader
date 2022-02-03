using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherArchives
{
    internal static class Values
    {
        internal const string MainMenuEnds = "to download...";
        internal const string appTitle = "WEATHER ARCHIVES";
        internal const string pageAdress = "http://flymet.meteopress.cz/";
        internal static string completePath;
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
