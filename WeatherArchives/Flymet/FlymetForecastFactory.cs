using Flymet.Entities;
using Flymet.ManualData;
using Model;
using System;
using System.Collections.Generic;

namespace Flymet
{
    public class FlymetForecastFactory
    {
        private readonly IFileOperation _fileOperation;

        public FlymetForecastFactory(IFileOperation fileOperation)
        {
            _fileOperation = fileOperation;
        }

    
        public List<IGenerate> CreateWeatherForecasts()
        {
            var regionElement = _fileOperation.FileReader<FlymetUrlElement>(FlymetConstValue.RegionFilePath);
            var productElement = _fileOperation.FileReader<FlymetUrlElement>(FlymetConstValue.ProductFilePath);
            var timeElement = _fileOperation.FileReader<FlymetUrlElement>(FlymetConstValue.TimeFilePath);

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
        //public List<IGenerate> CreateWeatherForecasts(Func<string, List<ForecastUrlElement>> fileReader)
        //{
        //    var regionElement = fileReader(ConstantValue.regionFilePath);
        //    var productElement = fileReader(ConstantValue.productFilePath);
        //    var timeElement = fileReader(ConstantValue.timeFilePath);

        //    var selectedForecastElements = new List<IGenerate>();

        //    foreach (var RegionInput in regionElement)
        //    {
        //        foreach (var ProductInput in productElement)
        //        {
        //            foreach (var TimeInput in timeElement)
        //            {
        //                var forecastEntity = new WeatherForecast(RegionInput, ProductInput, TimeInput);
        //                selectedForecastElements.Add(forecastEntity);
        //            }
        //        }
        //    }
        //    return selectedForecastElements;
        //}

    }
}
