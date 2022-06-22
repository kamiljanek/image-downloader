using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Model
{
    public class FileOperation : IFileOperation
    {
        /// <summary>
        /// Create *.json file with settings that user choose
        /// </summary>
        /// <param name="jsonFilePath">New *.json file name or whole path</param>
        /// <param name="selectedItems">Item to convert to *.json format</param>
        public void FileGenerator(string jsonFilePath, object selectedItems)
        {
            var itemSerialized = JsonConvert.SerializeObject(selectedItems);
            File.WriteAllText(jsonFilePath, itemSerialized);
        }
        /// <summary>
        /// Create list of items from existing *.json file
        /// </summary>
        /// <typeparam name="T">Type of list</typeparam>
        /// <param name="filePath">*.json file name or whole path</param>
        /// <returns></returns>
        public List<T> FileReader<T>(string filePath)
        {
            var itemSerialized = File.ReadAllText(filePath);
            List<T> item = JsonConvert.DeserializeObject<List<T>>(itemSerialized);

            return item;
        }
        /// <summary>
        /// Create item from existing *.json file
        /// </summary>
        /// <typeparam name="T">Type of item</typeparam>
        /// <param name="filePath">*.json file name or whole path</param>
        /// <returns></returns>
        public T FileGmailReader<T>(string filePath)
        {
            var itemSerialized = File.ReadAllText(filePath);
            T item = JsonConvert.DeserializeObject<T>(itemSerialized);

            return item;
        }
    }
}
