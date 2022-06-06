using Flymet;
using System.Collections.Generic;
using System.Net;

namespace ImageDownloader
{
    internal static class Download
    {
        /// <summary>
        /// Download every item from list
        /// </summary>
        /// <param name="selectedForecastElements">List of complete items todownload</param>
        public static void Downloader(this List<WeatherForecast> selectedForecastElements)
        {
            foreach (var item in selectedForecastElements)
            {
                string URL = item.GenerateUrl();
                string fileName = $"{item.ForecastRegion.Name} - {item.ForecastProduct.Name} - {item.ForecastTime.Name}{WeatherForecast.UrlExtencion}";
                WebClient webClient = new WebClient();
                webClient.DownloadFile(URL, fileName);
            }
        }
    }
}