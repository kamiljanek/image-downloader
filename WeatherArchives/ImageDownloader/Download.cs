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
        internal void DownloadFile(string link, string path)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFile(link, path);
        }
    }
}

