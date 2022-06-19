using Model;

namespace SynopticMap
{
    public class SynopticForecastFactory : IGenerate
    {
        private readonly string _fileName = @"synoptic_map.gif";
        private readonly string _url = @"https://www.chmi.cz/files/portal/docs/meteo/om/evropa/preba/preba.gif";
        private readonly string _name = "Synoptic_map";
        public string Name => _name;



        public string GenerateFileName()
        {
            return _fileName;
        }

        public string GenerateUrl()
        {
            return _url;
        }
    }
}
