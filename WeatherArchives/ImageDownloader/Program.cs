﻿using Flymet;
using SynopticMap;
using Model;
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

            var weatherForecastFactory = ServiceProvider.GetService<FlymetForecastFactory>();
            var synopticForecast = ServiceProvider.GetService<SynopticForecastFactory>();
            var image = ServiceProvider.GetService<DownloadElement>();
            var emailSender = ServiceProvider.GetService<EmailSender>();

            var selectedForecastElements = weatherForecastFactory.CreateWeatherForecasts();

            image.AddElement(selectedForecastElements);
            image.AddElement(synopticForecast);
            image.Elements.Download();

            emailSender.SendEmail(selectedForecastElements[0]);
            emailSender.SendEmail(synopticForecast);
        }
        public static ServiceProvider ServiceProvider { get; private set; }
        private static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton<FlymetForecastFactory>()
                .AddSingleton<SynopticForecastFactory>()
                .AddSingleton<DownloadElement>()
                .AddSingleton<EmailSender>()
                .AddSingleton<IFileOperation, FileOperation>();
        }


      

       

    }
}
