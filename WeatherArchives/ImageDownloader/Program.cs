using Flymet;
using SynopticMap;
using Helper;
using Microsoft.Extensions.DependencyInjection;

namespace ImageDownloader
{
    public class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            var weatherForecastFactory = ServiceProvider.GetService<WeatherForecastFactory>();
            var synopticForecast = ServiceProvider.GetService<SynopticForecastFactory>();
            var image = ServiceProvider.GetService<Forecast>();
            var emailSender = ServiceProvider.GetService<EmailSender>();

            var selectedForecastElements = weatherForecastFactory.CreateWeatherForecasts();
            //var selectedForecastElements = weatherForecastFactory.CreateWeatherForecasts(fileOperation.FileReader<ForecastUrlElement>);

            image.AddToImages(selectedForecastElements);
            image.AddToImages(synopticForecast);
            image.images.Download();

            emailSender.Sender(selectedForecastElements[0]);
            emailSender.Sender(synopticForecast);
        }
        public static ServiceProvider ServiceProvider { get; private set; }
        private static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton<FileOperation>()
                .AddSingleton<WeatherForecastFactory>()
                .AddSingleton<SynopticForecastFactory>()
                .AddSingleton<EmailSender>()
                .AddSingleton<Forecast>();
        }


      

       

    }
}
