using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flymet;
using Helper;

namespace ImageDownloader
{
    public class Forecast
    {
        public Dictionary<string, string> images = new Dictionary<string, string>();
        public void AddToImages(List<IGenerate> products)
        {
            foreach (var item in products)
            {
                images.Add(item.GenerateUrl(), item.GenerateFileName());
            }
        }
        public void AddToImages(IGenerate product)
        {
            images.Add(product.GenerateUrl(), product.GenerateFileName());
        }
    }
}
