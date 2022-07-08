using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;

namespace Model
{
    public class FileOperation : IFileOperation
    {
        private readonly IFileSystem _fileSystem;
        public FileOperation(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }
        /// <summary>
        /// Create *.json file with settings that user choose
        /// </summary>
        /// <param name="jsonFilePath">New *.json file name or whole path</param>
        /// <param name="selectedItems">Item to convert to *.json format</param>
        public void FileGenerator(string jsonFilePath, object selectedItems)
        {
            var itemSerialized = JsonConvert.SerializeObject(selectedItems);
            _fileSystem.File.WriteAllText(jsonFilePath, itemSerialized);
        }
        /// <summary>
        /// Create item from existing *.json file
        /// </summary>
        /// <typeparam name="T">Type of item</typeparam>
        /// <param name="filePath">*.json file name or whole path</param>
        /// <returns></returns>
        public T FileReader<T>(string filePath)
        {
            var itemSerialized = _fileSystem.File.ReadAllText(filePath);
            T item = JsonConvert.DeserializeObject<T>(itemSerialized);

            return item;
        }
    }
}
