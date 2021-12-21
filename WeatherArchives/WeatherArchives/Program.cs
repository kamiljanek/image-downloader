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
        static List<ChoosingEntity> weatherDaysInput = new List<ChoosingEntity>();
        static List<ChoosingEntity> weatherTypesInput = new List<ChoosingEntity>();
        static List<ChoosingEntity> weatherHoursInput = new List<ChoosingEntity>();
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
                    //firstPartLinks = GenerateFirstPartLink();
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
            //static List<string> GenerateFirstPartLink()
            //{
            //    Console.WriteLine("\tWrite numbers which days do you want to download:");
            //    chooseDayList = new List<ChoosingEntity>
            //{
            //     new ChoosingEntity("1", "cr/", "Today"),
            //     new ChoosingEntity("2","crdl/","Tomorrow"),
            //     new ChoosingEntity("3","crdl1/","Day After Tomorrow")
            //};

            //    foreach (ChoosingEntity val in chooseDayList)
            //    {
            //        Console.WriteLine($"{val.Id} - {val.Name}");
            //    }
            //    Console.WriteLine("\te.g. 1,3");
            //    string numbersDayInput = Console.ReadLine();
            //    string[] numberDayInputs = numbersDayInput.Split(',');

            //    var selectedFirstPartCodesList = new List<string>();

            //    foreach (string val in numberDayInputs)
            //    {
            //        var linkFirstPart = chooseDayList.Find(x => x.Id == val);
            //        selectedFirstPartCodesList.Add(linkFirstPart.Code);
            //    }
            //    return selectedFirstPartCodesList;

            //}

            static List<ChoosingEntity> ColectWeatherDaysInput()
            {
                Console.WriteLine("\tWrite numbers which days do you want to download:");
                var chooseDayList = new List<ChoosingEntity>
            {
                 new ChoosingEntity("1", "cr/", "Today"),
                 new ChoosingEntity("2","crdl/","Tomorrow"),
                 new ChoosingEntity("3","crdl1/","Day After Tomorrow")
            };

                foreach (ChoosingEntity val in chooseDayList)
                {
                    Console.WriteLine($"{val.Id} - {val.Name}");
                }
                Console.WriteLine("\te.g. 1,3");
                string numbersDayInput = Console.ReadLine();
                string[] numberDayInputs = numbersDayInput.Split(',');

                var selectedFirstPartCodesList = new List<ChoosingEntity>();

                foreach (string val in numberDayInputs)
                {
                    var linkFirstPart = chooseDayList.Find(x => x.Id == val);
                    selectedFirstPartCodesList.Add(linkFirstPart);
                }
                return selectedFirstPartCodesList;

            }
            static List<ChoosingEntity> ColectWeatherTypesInput()
            {
                Console.WriteLine("\tWrite numbers which elements are you looking for");
                var weatherPropertiesList = new List<ChoosingEntity> {
                new ChoosingEntity("1","oblcX","All Clouds"),
                new ChoosingEntity("2","srzk","Precipitation"),
                new ChoosingEntity("3","t2m","Temperature"),
                new ChoosingEntity("4","vitrx","Wind 10m"),
                new ChoosingEntity("5","vitry","Gust"),
                new ChoosingEntity("6","vitra","Wind 850 hPa"),
                new ChoosingEntity("7","vitrb","Wind 800 hPa"),
                new ChoosingEntity("8","drtr","Kind of Thermals"),
                new ChoosingEntity("9","cudf","Convective Temperature Deficit"),
                new ChoosingEntity("10","cukh","Cumulus Clouds"),
                new ChoosingEntity("11","cuvr","Climb Speed")
                };

                foreach (ChoosingEntity val in weatherPropertiesList)
                {
                    Console.WriteLine($"{val.Id} - {val.Name}");
                }
                Console.WriteLine("\te.g. 1,2,5,8");

                string numbersWeatherPropertiesInput = Console.ReadLine();
                string[] numberWeatherPropetiesInputs = numbersWeatherPropertiesInput.Split(',');

                var selectedSecondPartCodesList = new List<ChoosingEntity>();

                foreach (string val in numberWeatherPropetiesInputs)
                {
                    var linkSecondPart = weatherPropertiesList.Find(x => x.Id == val);
                    selectedSecondPartCodesList.Add(linkSecondPart);

                }
                return selectedSecondPartCodesList;
            }

            static List<ChoosingEntity> ColectWeatherHoursInput()
            {
                var weatherHoursList = new List<ChoosingEntity>(); 
               
                for (int hour = 1; hour < 25; hour++)
                {
                    var stringifiedHour = hour.ToString();
                    weatherHoursList.Add(new ChoosingEntity(stringifiedHour,stringifiedHour,stringifiedHour));
                }

                Console.WriteLine("\tWhat time are you looking for?");
                Console.WriteLine("\te.g.   9,12,15,17");

                string numbersTimeInput = Console.ReadLine();
                string[] numberTimeInputs = numbersTimeInput.Split(",");

                var selectedThirdPartCodesList = new List<ChoosingEntity>();

                foreach (string val in numberTimeInputs)
                {
                    var linkTrirdPart = weatherHoursList.Find(x => x.Id == val);
                    selectedThirdPartCodesList.Add(linkTrirdPart);
                }
                return selectedThirdPartCodesList;

            }
            static void StartDownload(List<WeatherForecastEntity> weatherForcastEntityList)
            {
                foreach (var weatherForecastEntity in weatherForcastEntityList)
                {
                    weatherForecastEntity.DownloadFile();
                }

            }
            static List<WeatherForecastEntity> GenerateDownloadItems()
            {
                //string mainLink = "http://flymet.meteopress.cz/";
                var selectedCompleateLinksList = new List<WeatherForecastEntity>();

                foreach (var weatherDayInput in weatherDaysInput)
                {
                    foreach (var weatherTypeInput in weatherTypesInput)
                    {
                        foreach (var weatherHourInput in weatherHoursInput)
                        {
                            var weatherForecastEntity = new WeatherForecastEntity(weatherDayInput, weatherTypeInput, weatherHourInput);
                            //string completeLink = $"{mainLink}{weatherDayInput}{secondPartLink}{thirdPartLink}.png";
                            //Console.WriteLine(completeLink);
                            selectedCompleateLinksList.Add(weatherForecastEntity);
                        }
                    }

                }
                return selectedCompleateLinksList;

            }
            static bool Confirmation()
            {
                Console.WriteLine("If you are sure press \"ENTER\", if not press any other key...");

                return Console.ReadKey().Key == ConsoleKey.Enter;

            }
            static string GeneratorFolderPath()
            {
                Console.WriteLine("Name your new folder");
                NameFolder nameFolder = new NameFolder();
                nameFolder.Name = Console.ReadLine();
                Console.WriteLine("Paste localization");
                string localization = Console.ReadLine();

                string completePath = $"{localization}\\{nameFolder.Name}";

                Console.WriteLine(completePath);
                return completePath;
            }

            static void CreateFolder(string path)
            {
                Directory.CreateDirectory(path);
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
