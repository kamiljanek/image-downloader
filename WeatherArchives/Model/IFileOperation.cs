using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IFileOperation
    {
        void FileGenerator(string jsonFilePath, object selectedItems);
        T FileReader<T>(string filePath);
    }
}
