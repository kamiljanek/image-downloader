using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WeatherArchives
{
    public static class CreateEntity
    {
        public static void CreateFolder(string folderPath)
        {
            Directory.CreateDirectory(folderPath);
        }
    }
}
