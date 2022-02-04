using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace WeatherArchives
{
    public class ForecastElement
    {
        public ForecastElement(string id, string code, string name)
        {
            Id = id;
            Code = code;
            Name = name;
        }
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
