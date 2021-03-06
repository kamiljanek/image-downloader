using Flymet.Entities;
using Flymet.ManualData;
using Model;
using System;
using System.Collections.Generic;

namespace Flymet
{
    public class FlymetForecastFactory : IFlymetForecastFactory
    {
        private readonly IFileOperation _fileOperation;

        public FlymetForecastFactory(IFileOperation fileOperation)
        {
            _fileOperation = fileOperation;
        }

        public List<IGenerate> CreateWeatherForecasts()
        {
            var regionElement = _fileOperation.FileReader<List<FlymetUrlElement>>(FlymetConstValue.RegionFilePath);
            var productElement = _fileOperation.FileReader<List<FlymetUrlElement>>(FlymetConstValue.ProductFilePath);
            var timeElement = _fileOperation.FileReader<List<FlymetUrlElement>>(FlymetConstValue.TimeFilePath);

            var selectedForecastElements = new List<IGenerate>();

            foreach (var RegionInput in regionElement)
            {
                foreach (var ProductInput in productElement)
                {
                    foreach (var TimeInput in timeElement)
                    {
                        var forecastEntity = new FlymetForecast(RegionInput, ProductInput, TimeInput);
                        selectedForecastElements.Add(forecastEntity);
                    }
                }
            }
            return selectedForecastElements;
        }
    }
}
