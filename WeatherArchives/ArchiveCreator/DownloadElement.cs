using Model;
using System.Collections.Generic;

namespace ArchiveCreator
{
    public class DownloadElement
    {
        //private Dictionary<string, string> _elements = new Dictionary<string, string>();
        //public Dictionary<string, string> Elements => _elements;
        public Dictionary<string, string> Elements { get; private set; }
        public void AddElement(List<IGenerate> products)
        {
            foreach (var item in products)
            {
                Elements.Add(item.GenerateUrl(), item.GenerateFileName());
            }
        }
        public void AddElement(IGenerate product)
        {
            Elements.Add(product.GenerateUrl(), product.GenerateFileName());
        }
        
    }
}
