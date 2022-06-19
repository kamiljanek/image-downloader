using Model;
using System.Collections.Generic;

namespace ArchiveCreator
{
    public class DownloadElement
    {
        private Dictionary<string, string> _elements = new Dictionary<string, string>();
        public Dictionary<string, string> Elements => _elements;

        public void AddElement(List<IGenerate> products)
        {
            foreach (var item in products)
            {
                _elements.Add(item.GenerateUrl(), item.GenerateFileName());
            }
        }
        public void AddElement(IGenerate product)
        {
            _elements.Add(product.GenerateUrl(), product.GenerateFileName());
        }
        
    }
}
