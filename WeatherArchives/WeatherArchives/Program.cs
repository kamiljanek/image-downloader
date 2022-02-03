using Grpc.Core;
using Slack.Webhooks.Blocks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace WeatherArchives
{
    class Program
    {

        static void Main(string[] args)
        {
            Values.Title();
            Menu.MainMenu();
        }

        #region Variable
        //static List<string> firstPartLinks = new List<string>();
        //static List<string> secondPartLinks = new List<string>();
        //static List<string> thirdPartLinks = new List<string>();

        //static List<ChoosingEntity> chooseDayList = new List<ChoosingEntity>();
        #endregion



        //static List<ForecastDay> ColectWeatherDaysInput()
        //{

        //    foreach (ForecastDay val in ForecastLists.forecastDayList)
        //    {
        //        Console.WriteLine($"{val.Id} - {val.Name}");
        //    }

        //    Console.WriteLine("\tChoose numbers...");
        //    Console.WriteLine("\tFor example: 1,3");
        //    string forecastDaysInput = Console.ReadLine();
        //    string[] forecastDayInputs = forecastDaysInput.Split(',');

        //    var selectedForecastDayList = new List<ForecastDay>();

        //    foreach (string val in forecastDayInputs)
        //    {
        //        var selectedForecastDay = ForecastLists.forecastDayList.Find(x => x.Id == val);
        //        selectedForecastDayList.Add(selectedForecastDay);
        //    }
        //    return selectedForecastDayList;

        //}
        //static List<ForecastType> ColectWeatherTypesInput()
        //{
        //    foreach (ForecastType val in ForecastLists.forecastTypeList)
        //    {
        //        Console.WriteLine($"{val.Id} - {val.Name}");
        //    }
        //    Console.WriteLine("\tChoose numbers...");
        //    Console.WriteLine("\tFor example: 1,3,7,9");

        //    string forecastTypesInput = Console.ReadLine();
        //    string[] forecastTypeInputs = forecastTypesInput.Split(',');

        //    var selectedForecastTypeList = new List<ForecastType>();

        //    foreach (string val in forecastTypeInputs)
        //    {
        //        var selectedForecastType = ForecastLists.forecastTypeList.Find(x => x.Id == val);
        //        selectedForecastTypeList.Add(selectedForecastType);

        //    }
        //    return selectedForecastTypeList;
        //}

        //static List<ForecastTime> ColectWeatherHoursInput()
        //{


        //    Console.WriteLine("\tChoose hours...");
        //    Console.WriteLine("\tFor example: 9,12,15,17");

        //    string forecastHoursInput = Console.ReadLine();
        //    string[] forecastHourInputs = forecastHoursInput.Split(",");

        //    var selectedForecastHourList = new List<ForecastTime>();

        //    foreach (string val in forecastHourInputs)
        //    {
        //        var selectedForecastHour = ForecastLists.HourList().Find(x => x.Id == val);
        //        selectedForecastHourList.Add(selectedForecastHour);
        //    }
        //    return selectedForecastHourList;

        //}
    
        //static List<WeatherForecast> GenerateDownloadItems()
        //{
        //    var selectedCompleateLinkList = new List<WeatherForecast>();

        //    foreach (var weatherDayInput in weatherDaysInput)
        //    {
        //        foreach (var weatherTypeInput in weatherTypesInput)
        //        {
        //            foreach (var weatherHourInput in weatherHoursInput)
        //            {
        //                var weatherForecastEntity = new WeatherForecast(weatherDayInput, weatherTypeInput, weatherHourInput);
        //                selectedCompleateLinkList.Add(weatherForecastEntity);
        //            }
        //        }

        //    }
        //    return selectedCompleateLinkList;

        //}



       

        static void CreateEachDayFolder(string eachDayFolder)
        {
            Directory.CreateDirectory($"{eachDayFolder}\\{DateTime.Now.ToString("dd.MM.yyyy")}");
        }

    }
}

