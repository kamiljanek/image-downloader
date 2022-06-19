using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flymet
{
    public interface IFileOperation
    {
        void FileGenerator(string jsonFilePath, object selectedItems);

        List<T> FileReader<T>(string filePath);
    }
}
