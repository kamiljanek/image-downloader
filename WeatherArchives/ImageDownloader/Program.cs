using Engine;
using System;
using System.IO;

namespace ImageDownloader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var data = new FileSetting();
            var daysReaded = data.FileReader(Values.regionFilePath, ForecastLists.forecastDaysInput);
            var typesReaded = data.FileReader(Values.productFilePath, ForecastLists.forecastTypesInput);
            var hoursReaded = data.FileReader(Values.timeFilePath, ForecastLists.forecastHoursInput);
            var emailReaded = data.FileReader(Values.emailInputsFilePath, Gmail.emailInput);

            var selectedForecastElements = ForecastLists.GenerateDownloadItems(daysReaded, typesReaded, hoursReaded);

            selectedForecastElements.Downloader();

            EmailSender.Sender(emailReaded[0],emailReaded[1]);

        }

    }
}
