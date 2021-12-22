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
            Title();
            MainMenu();
        }

        #region Variable
        //static List<string> firstPartLinks = new List<string>();
        //static List<string> secondPartLinks = new List<string>();
        //static List<string> thirdPartLinks = new List<string>();
        static List<WeatherDay> weatherDaysInput = new List<WeatherDay>();
        static List<WeatherType> weatherTypesInput = new List<WeatherType>();
        static List<WeatherHour> weatherHoursInput = new List<WeatherHour>();
        static string completePath;
        //static List<ChoosingEntity> chooseDayList = new List<ChoosingEntity>();
        #endregion

        static void Title()
        {
            string enter = "";
            string title = "WEATHER ARCHIVES";
            string pageAdress = "http://flymet.meteopress.cz/";
            Console.SetCursorPosition((Console.WindowWidth - pageAdress.Length) / 2, Console.CursorTop); //centering text
            Console.WriteLine(pageAdress);

            Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop); //centering text
            Console.WriteLine(title);
            Console.WriteLine(enter);
        }
        static void ClearWindow()
        {
            Console.Clear();
            Title();
        }
        static void MainMenu()          //TODO change menu to "while" construction
        {
            Console.Clear();
            Title();
            Console.WriteLine("1. Day?");
            Console.WriteLine("2. Type of Data?");
            Console.WriteLine("3. Time?");
            Console.WriteLine("4. Choose path");
            Console.WriteLine("5. Start Download");

            string opcionInput = Console.ReadLine();
            switch (opcionInput)
            {
                case "1":
                    ClearWindow();
                    weatherDaysInput = ColectWeatherDaysInput();
                    MainMenu();
                    break;

                case "2":

                    ClearWindow();
                    weatherTypesInput = ColectWeatherTypesInput();
                    MainMenu();
                    break;

                case "3":

                    ClearWindow();
                    weatherHoursInput = ColectWeatherHoursInput();
                    MainMenu();
                    break;

                case "4":

                    ClearWindow();
                    completePath = GeneratorFolderPath();
                    CreateFolder(completePath);
                    MainMenu();
                    break;

                case "5":

                    ClearWindow();
                    //GenerateAllChoosenProperties();

                    if (Confirmation())
                    {
                        
                    }
                    else
                    {
                        MainMenu();
                        break;
                    }
                    var weatherForcastEntityList = GenerateDownloadItems();
                    //CreateEachDayFolder(completePath);
                    StartDownload(weatherForcastEntityList);
                    break;

                default:

                    ClearWindow();
                    Console.WriteLine("WRONG CHOOISE!!! TRY ONE MORE TIME");
                    MainMenu();
                    break;

            }

            static List<WeatherDay> ColectWeatherDaysInput()
            {
                Console.WriteLine("\tWrite numbers which days do you want to download:");
                var weatherDayList = new List<WeatherDay>
            {
                 new WeatherDay("1", "cr/", "Today"),
                 new WeatherDay("2","crdl/","Tomorrow"),
                 new WeatherDay("3","crdl1/","Day After Tomorrow")
            };

                foreach (WeatherDay val in weatherDayList)
                {
                    Console.WriteLine($"{val.Id} - {val.Name}");
                }
                Console.WriteLine("\te.g. 1,3");
                string weatherDaysInput = Console.ReadLine();
                string[] weatherDayInputs = weatherDaysInput.Split(',');

                var selectedWeatherDayList = new List<WeatherDay>();

                foreach (string val in weatherDayInputs)
                {
                    var selectedWeatherDay = weatherDayList.Find(x => x.Id == val);
                    selectedWeatherDayList.Add(selectedWeatherDay);
                }
                return selectedWeatherDayList;

            }
            static List<WeatherType> ColectWeatherTypesInput()
            {
                Console.WriteLine("\tWrite numbers which elements are you looking for");
                var weatherTypeList = new List<WeatherType> {
                new WeatherType("1","oblcX","All Clouds"),
                new WeatherType("2","srzk","Precipitation"),
                new WeatherType("3","t2m","Temperature"),
                new WeatherType("4","vitrx","Wind 10m"),
                new WeatherType("5","vitry","Gust"),
                new WeatherType("6","vitra","Wind 850 hPa"),
                new WeatherType("7","vitrb","Wind 800 hPa"),
                new WeatherType("8","drtr","Kind of Thermals"),
                new WeatherType("9","cudf","Convective Temperature Deficit"),
                new WeatherType("10","cukh","Cumulus Clouds"),
                new WeatherType("11","cuvr","Climb Speed")
                };

                foreach (WeatherType val in weatherTypeList)
                {
                    Console.WriteLine($"{val.Id} - {val.Name}");
                }
                Console.WriteLine("\te.g. 1,2,5,8");

                string WeatherTypesInput = Console.ReadLine();
                string[] WeatherTypeInputs = WeatherTypesInput.Split(',');

                var selectedWeatherTypeList = new List<WeatherType>();

                foreach (string val in WeatherTypeInputs)
                {
                    var selectedWeatherType = weatherTypeList.Find(x => x.Id == val);
                    selectedWeatherTypeList.Add(selectedWeatherType);

                }
                return selectedWeatherTypeList;
            }

            static List<WeatherHour> ColectWeatherHoursInput()
            {
                var weatherHourList = new List<WeatherHour>(); 
               
                for (int hour = 1; hour < 25; hour++)
                {
                    var stringifiedHour = hour.ToString();
                    weatherHourList.Add(new WeatherHour(stringifiedHour,stringifiedHour,stringifiedHour));
                }

                Console.WriteLine("\tWhat time are you looking for?");
                Console.WriteLine("\te.g.   9,12,15,17");

                string weatherHoursInput = Console.ReadLine();
                string[] weatherHourInputs = weatherHoursInput.Split(",");

                var selectedWeatherHourList = new List<WeatherHour>();

                foreach (string val in weatherHourInputs)
                {
                    var selectedWeatherHour = weatherHourList.Find(x => x.Id == val);
                    selectedWeatherHourList.Add(selectedWeatherHour);
                }
                return selectedWeatherHourList;

            }
            static void StartDownload(List<WeatherForecast> selectedWeatherForcastList)
            {
                foreach (var val in selectedWeatherForcastList)
                {
                    val.DownloadFile();
                }

            }
            static List<WeatherForecast> GenerateDownloadItems()
            {
                var selectedCompleateLinkList = new List<WeatherForecast>();

                foreach (var weatherDayInput in weatherDaysInput)
                {
                    foreach (var weatherTypeInput in weatherTypesInput)
                    {
                        foreach (var weatherHourInput in weatherHoursInput)
                        {
                            var weatherForecastEntity = new WeatherForecast(weatherDayInput, weatherTypeInput, weatherHourInput);
                            selectedCompleateLinkList.Add(weatherForecastEntity);
                        }
                    }

                }
                return selectedCompleateLinkList;

            }
            static bool Confirmation()
            {
                Console.WriteLine("If you are sure press \"ENTER\", if not press any other key...");

                return Console.ReadKey().Key == ConsoleKey.Enter;

            }
            static string GeneratorFolderPath()
            {
                Console.WriteLine("Name your new folder");
                var folderName = Console.ReadLine();
                Console.WriteLine("Paste localization");
                var localizationOnComputer = Console.ReadLine();

                var folderPath = $"{localizationOnComputer}\\{folderName}";

                return folderPath;
            }

            static void CreateFolder(string folderPath)
            {
                Directory.CreateDirectory(folderPath);
            }

            static void CreateEachDayFolder(string eachDayFolder)
            {
                Directory.CreateDirectory($"{eachDayFolder}\\{DateTime.Now.ToString("dd.MM.yyyy")}");
            }
            //static void GenerateAllChoosenProperties()
            //{
            //    foreach (string val in firstPartLinks)
            //    {
            //        foreach (ChoosingEntity y in chooseDayList)
            //        {
            //            if (val == y.Code)
            //            {
            //                Console.Write($"{y.Name}, ");
            //            }
            //        }
            //    }
            //    Console.WriteLine();
            //    Console.WriteLine();
            //    foreach (string val in secondPartLinks)
            //    {
            //        foreach (ChoosingEntity y in weatherPropertiesList)
            //        {
            //            if (val == y.Code)
            //            {
            //                Console.Write($"{y.Name}, ");
            //            }
            //        }
            //    }
            //    Console.WriteLine();
            //    Console.WriteLine();
            //    foreach (string val in thirdPartLinks)
            //    {
            //        Console.Write($"{val}:00, ");
            //    }
            //    Console.WriteLine();
            //    Console.WriteLine();
            //    Console.WriteLine($"Path: {completePath}");
            //    Console.WriteLine();
            //    Console.WriteLine();
            //}

            //TODO create time downloader
        }
    } 
}
