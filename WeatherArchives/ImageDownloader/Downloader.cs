using Flymet;
using System.Collections.Generic;
using System.Net;

namespace ImageDownloader
{
    public static class Downloader
    {
        /// <summary>
        /// Download every item from list
        /// </summary>
        /// <param name="selectedForecastElements">List of complete items todownload</param>
        public static void Download(this List<FlymetForecast> selectedForecastElements)
        {
            foreach (var item in selectedForecastElements)
            {
                string Url = item.GenerateUrl();
                string fileName = $"{item.ForecastRegion.Name}-{item.ForecastProduct.Name}-{item.ForecastTime.Name}{FlymetConstValue.UrlExtencion}";
                WebClient webClient = new WebClient();
                webClient.DownloadFile(Url, fileName);
            }
        }
        public static void Download(this Dictionary<string, string> images)
        {
            foreach (var item in images)
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFile(item.Key, item.Value);
            }
        }
    }
}