using Flymet;
using System;
using System.IO;

namespace ImageDownloader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileOperation = new FileOperation();
            var fileReadedRegion = fileOperation.FileReader<ForecastUrlElement>(Values.regionFilePath);
            var fileReadedProduct = fileOperation.FileReader<ForecastUrlElement>(Values.productFilePath);
            var fileReadedTime = fileOperation.FileReader<ForecastUrlElement>(Values.timeFilePath);
            var fileReadedGmail = fileOperation.FileReader<string>(Values.gmailFilePath);

            var selectedForecastElements = FlymetLinkParts.GenerateWeatherForecasts(fileReadedRegion, fileReadedProduct, fileReadedTime);

            selectedForecastElements.Downloader();

            EmailSender.Sender(fileReadedGmail[0],fileReadedGmail[1]);

        }

    }
}
