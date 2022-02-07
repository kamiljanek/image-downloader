using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherArchives;

namespace ImageDownloader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            while (i < 5)
            {
                Folder folder = new Folder();
                string dateTime = DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss");
                //string eachDayFolder = folder.NewFolderPath(dateTime);
                //CreateEntity.CreateFolder(eachDayFolder);
                //DbManager dbManager = new DbManager();
                //List<string> URLs = dbManager.URLListGenerator();
                //int h = 0;
                //foreach (var item in URLs)
                //{
                //    Download download = new Download();
                //    download.DownloadFile(item, $"{eachDayFolder}\\{h}.png");
                //    h++;
                //}
                var delay = Task.Delay(1001);
                delay.Wait();
             
                i++;
            }
        }
    }
}
