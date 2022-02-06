using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherArchives
{
    public static class Values
    {
        internal const string dbo_URLs = "URLs";
        internal const string dbo_OwnersData = "OwnersData";
        internal const string MainMenuEnds = "to download...";
        internal const string dayInputsFile = "dayInputsData.txt";
        internal const string typeInputsFile = "typeInputsData.txt";
        internal const string hourInputsFile = "hourInputsData.txt";
        internal const string archiveFile = "archivePath.txt";
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
  
    }
}
