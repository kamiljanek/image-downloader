using Engine;
using System.Collections.Generic;
using System.Net;

namespace ImageDownloader
{
    internal static class Download
    {
        public static string eachDayFolderPath;
        internal static void Downloader(this List<WeatherForecast> selectedForecastElements)
        {
            foreach (var item in selectedForecastElements)
            {
                string URL = item.GenerateUrl();
                string fileName = $"{item.ForecastDay.Name} - {item.ForecastType.Name} - {item.ForecastHour.Name}{WeatherForecast.UrlExtencion}";
                //string filePath = $"{eachDayFolderPath}\\{fileName}";
                WebClient webClient = new WebClient();
                webClient.DownloadFile(URL, fileName);

            }
        }

    }
}

