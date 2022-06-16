using Flymet;

namespace ImageDownloader
{
    public class Program
    {
        static void Main(string[] args)
        {
            var fileOperation = new FileOperation();
            var frWeather = new FileReaderDelegate<ForecastUrlElement>(fileOperation.FileReader<ForecastUrlElement>);
            var frGmail = new FileReaderDelegate<string>(fileOperation.FileReader<string>);
            var weatherForecastFactory = new WeatherForecastFactory();
            var emailSender = new EmailSender();


            //var fileReadedRegion = fileOperation.FileReader<ForecastUrlElement>(ConstantValue.regionFilePath);
            //var fileReadedProduct = fileOperation.FileReader<ForecastUrlElement>(ConstantValue.productFilePath);
            //var fileReadedTime = fileOperation.FileReader<ForecastUrlElement>(ConstantValue.timeFilePath);
            //var fileReadedGmail = fileOperation.FileReader<string>(ConstantValue.gmailFilePath);


            //var selectedForecastElements = weatherForecastFactory.CreateWeatherForecasts(fileReadedRegion, fileReadedProduct, fileReadedTime);
            var selectedForecastElements = weatherForecastFactory.CreateWeatherForecasts(
                frWeather(ConstantValue.regionFilePath),
                frWeather(ConstantValue.productFilePath),
                frWeather(ConstantValue.timeFilePath));

            selectedForecastElements.Downloader();

            //emailSender.Sender(fileReadedGmail[0], fileReadedGmail[1]);
            emailSender.Sender(frGmail(ConstantValue.gmailFilePath)[0], frGmail(ConstantValue.gmailFilePath)[1]);

        }

    }
}
