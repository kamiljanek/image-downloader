using Helper;

namespace SynopticMap
{
    public class SynopticForecastFactory : IGenerate
    {
        private readonly string _name = "Synoptic_map";
        public string Name => _name;

        private const string url = @"https://www.chmi.cz/files/portal/docs/meteo/om/evropa/preba/preba.gif";
        private const string fileName = @"synoptic_map.gif";


        public string GenerateFileName()
        {
            return fileName;
        }

        public string GenerateUrl()
        {
            return url;
        }
    }
}
