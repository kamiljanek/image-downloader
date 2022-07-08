using Model;
using System.Collections.Generic;

namespace Flymet
{
    public interface IFlymetForecastFactory
    {
        List<IGenerate> CreateWeatherForecasts();
    }
}