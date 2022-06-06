using Flymet;
using System;
using System.IO;

namespace ImageDownloader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var data = new FileOperation();
            var fileReadedRegion = data.FileReader<ForecastUrlElement>(Values.regionFilePath);
            var fileReadedProduct = data.FileReader<ForecastUrlElement>(Values.productFilePath);
            var fileReadedTime = data.FileReader<ForecastUrlElement>(Values.timeFilePath);
            var fileReadedGmail = data.FileReader<string>(Values.gmailFilePath);

            var selectedForecastElements = FlymetData.GenerateDownloadItems(fileReadedRegion, fileReadedProduct, fileReadedTime);

            selectedForecastElements.Downloader();

            EmailSender.Sender(fileReadedGmail[0],fileReadedGmail[1]);

        }

    }
}
