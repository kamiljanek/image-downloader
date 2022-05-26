using Flymet;
using System;
using System.IO;

namespace ImageDownloader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var data = new FileSetting();
            var fileReadedRegion = data.FileReader<ForecastElement>(Values.regionFilePath);
            var fileReadedProduct = data.FileReader<ForecastElement>(Values.productFilePath);
            var fileReadedTime = data.FileReader<ForecastElement>(Values.timeFilePath);
            var fileReadedGmail = data.FileReader<string>(Values.gmailFilePath);

            var selectedForecastElements = FlymetData.GenerateDownloadItems(fileReadedRegion, fileReadedProduct, fileReadedTime);

            selectedForecastElements.Downloader();

            EmailSender.Sender(fileReadedGmail[0],fileReadedGmail[1]);

        }

    }
}
