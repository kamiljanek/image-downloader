using Helper;
using System;
using System.Collections.Generic;

namespace Flymet
{
    public class WeatherForecastFactory
    {
        private readonly FileOperation _fileOperation;

        public WeatherForecastFactory(FileOperation fileOperation)
        {
            _fileOperation = fileOperation;
        }

    
        public List<IGenerate> CreateWeatherForecasts()
        {
            var regionElement = _fileOperation.FileReader<ForecastUrlElement>(ConstantValue.regionFilePath);
            var productElement = _fileOperation.FileReader<ForecastUrlElement>(ConstantValue.productFilePath);
            var timeElement = _fileOperation.FileReader<ForecastUrlElement>(ConstantValue.timeFilePath);

            var selectedForecastElements = new List<IGenerate>();

            foreach (var RegionInput in regionElement)
            {
                foreach (var ProductInput in productElement)
                {
                    foreach (var TimeInput in timeElement)
                    {
                        var forecastEntity = new WeatherForecast(RegionInput, ProductInput, TimeInput);
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
