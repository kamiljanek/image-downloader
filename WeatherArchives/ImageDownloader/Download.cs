using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ImageDownloader
{
    internal class Download
    {
        List<string> URLs;
        string filePath;
        internal void DownloadFile()
        {
            Query query = new Query();
            URLs = query.URLListGenerator();
            filePath = query.FilePathGenerator();
            WebClient webClient = new WebClient();
            foreach (var item in URLs)
            {
                webClient.DownloadFile(item, filePath);

            }
        }
    }
}
