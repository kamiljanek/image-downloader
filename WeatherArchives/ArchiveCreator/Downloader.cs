using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace ArchiveCreator
{
    public static class Downloader
    {
        /// <summary>
        /// Asynchronously download every item from list
        /// </summary>
        /// <param name="elements">Dictionary of complete elements to download</param>
        public static async Task Download(this Dictionary<string, string> elements)
        {

            HttpClient httpClient = new HttpClient();
            foreach (var item in elements)
            {
                try
                {
                    using (var stream = await httpClient.GetStreamAsync(item.Key))
                    {
                        using (var fileStream = new FileStream(item.Value, FileMode.Create))
                        {
                            await stream.CopyToAsync(fileStream);
                        }
                    }
                }
                catch (Exception msg)
                {
                    Console.WriteLine(msg.Message);
                }

            }
        }
    }
}
