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
    public class ForecastDay : ForecastElement
    {
        public ForecastDay(string id, string code, string name) : base (id, code, name)
        {

        }
    }
    public class ForecastType : ForecastElement
    {
        public ForecastType(string id, string code, string name) : base(id, code, name)
        {

        }
    }
    public class ForecastTime : ForecastElement
    {
        public ForecastTime(string id, string code, string name) : base(id, code, name)
        {

        }
    }
    
}
