﻿using Engine;
using System;
using System.IO;

namespace ImageDownloader
{
    internal class Program
    {
        static string dateTime = DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss");
        static void Main(string[] args)
        {
            var data = new Data();
            var daysReaded = data.FileReader(Values.dayInputsFilePath, ForecastLists.forecastDaysInput);
            var typesReaded = data.FileReader(Values.typeInputsFilePath, ForecastLists.forecastTypesInput);
            var hoursReaded = data.FileReader(Values.hourInputsFilePath, ForecastLists.forecastHoursInput);

            StreamReader sr = File.OpenText(Values.archiveFilePath);
            string pathReaded = sr.ReadLine();

            var selectedForecastElements = ForecastLists.GenerateDownloadItems(daysReaded, typesReaded, hoursReaded);

            Download.eachDayFolderPath = $"{pathReaded}\\{dateTime}";
            Directory.CreateDirectory(Download.eachDayFolderPath);   //create new folder

            selectedForecastElements.Downloader();



        }

    }
}
