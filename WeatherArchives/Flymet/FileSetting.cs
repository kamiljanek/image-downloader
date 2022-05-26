using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Flymet
{
    public class FileSetting
    {
          public void FileGenerator(string jsonFilePath, object selectedItems)
        {
            var itemSerialized = JsonConvert.SerializeObject(selectedItems);
            File.WriteAllText(jsonFilePath, itemSerialized);
        }
        public List<T> FileReader<T>(string filePath)
        {
            var itemSerialized = File.ReadAllText(filePath);
            List<T> item = JsonConvert.DeserializeObject<List<T>>(itemSerialized);
        
            return item;
        }
     }
}
