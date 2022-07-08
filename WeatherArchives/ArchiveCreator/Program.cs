using System.IO.Abstractions;
using Flymet;
using Model;
using Microsoft.Extensions.DependencyInjection;
using SynopticMap;
using System.Threading.Tasks;

namespace ArchiveCreator
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            var weatherForecastFactory = ServiceProvider.GetService<IFlymetForecastFactory>();
            var synopticForecast = ServiceProvider.GetService<SynopticForecastFactory>();
            var image = ServiceProvider.GetService<DownloadElement>();
            var emailSender = ServiceProvider.GetService<EmailSender>();

            var selectedForecastElements = weatherForecastFactory.CreateWeatherForecasts();

            image.AddElement(selectedForecastElements);
            image.AddElement(synopticForecast);
            await image.Elements.Download();

            emailSender.SendEmail(selectedForecastElements[0]);
            emailSender.SendEmail(synopticForecast);
        }
        public static ServiceProvider ServiceProvider { get; private set; }
        private static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton<IFlymetForecastFactory, FlymetForecastFactory>()
                .AddSingleton<SynopticForecastFactory>()
                .AddSingleton<DownloadElement>()
                .AddSingleton<EmailSender>()
                .AddSingleton<IFileOperation, FileOperation>()
                .AddSingleton<IFileSystem, FileSystem>();
        }
    }
}
