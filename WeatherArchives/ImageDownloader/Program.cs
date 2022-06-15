using Flymet;
using System;
using System.IO;

namespace ImageDownloader
{
    public class Program
    {
        static void Main(string[] args)
        {
            var fileOperation = new FileOperation();
            var weatherForecastFactory = new WeatherForecastFactory();
            var emailSender = new EmailSender();

            
            
            var fileReadedRegion = fileOperation.FileReader<ForecastUrlElement>(ConstantValue.regionFilePath);
            var fileReadedProduct = fileOperation.FileReader<ForecastUrlElement>(ConstantValue.productFilePath);
            var fileReadedTime = fileOperation.FileReader<ForecastUrlElement>(ConstantValue.timeFilePath);
            var fileReadedGmail = fileOperation.FileReader<string>(ConstantValue.gmailFilePath);



            var selectedForecastElements = weatherForecastFactory.CreateWeatherForecasts(fileReadedRegion, fileReadedProduct, fileReadedTime);

            selectedForecastElements.Downloader();

            emailSender.Sender(fileReadedGmail[0],fileReadedGmail[1]);

        }

    }
}
