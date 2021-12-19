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

        static List<string> firstPartLinks = new List<string>();
        static List<string> secondPartLinks = new List<string>();
        static List<string> thirdPartLinks = new List<string>();
        static List<string> completeLinksList = new List<string>();
        static string completePath;
        static List<ChoosingProperties> weatherPropertiesList = new List<ChoosingProperties>();
        
        
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
        static void MainMenu()
        {
            Console.Clear();
            Title();
            Console.WriteLine("1. Day?");
            Console.WriteLine("2. Type of Data?");
            Console.WriteLine("3. Time?");
            Console.WriteLine("4. Choose path");
            Console.WriteLine("5. Start Download");

            string opcionInput = Console.ReadLine();
            if (opcionInput == "1")
            {
                ClearWindow();
                firstPartLinks = GenerateFirstPartLink();
                MainMenu();
            }
            else if (opcionInput == "2")
            {
                ClearWindow();
                secondPartLinks = GenerateSecondPartLink();
                MainMenu();
            }
            else if (opcionInput == "3")
            {
                ClearWindow();
                thirdPartLinks = GenerateThirdPartLink();
                MainMenu();
            }
            else if (opcionInput == "4")
            {
                ClearWindow();
                completePath = GeneratorFolderPath();
                CreateFolder(completePath);
                MainMenu();

            }
            else if (opcionInput == "5")
            {
                ClearWindow();
                //GenerateAllProperties();
                Confirmation();
                completeLinksList = GenerateCompleteLinks();
                //CreateEachDayFolder(completePath);
                StartDownload();
            }
            else
            {
                ClearWindow();
                Console.WriteLine("WRONG CHOOISE!!! TRY ONE MORE TIME");
                MainMenu();
            }
        }
        static List<string> GenerateFirstPartLink()
        {
            Console.WriteLine("\tWrite numbers which days do you want to download:");
            var chooseDayList = new List<ChoosingProperties>
            {
                 new ChoosingProperties("1", "cr/", "Today"),
                 new ChoosingProperties("2","crdl/","Tomorrow"),
                 new ChoosingProperties("3","crdl1/","Day After Tomorrow")
            };

            foreach (ChoosingProperties val in chooseDayList)
            {
                Console.WriteLine($"{val.Id} - {val.Name}");
            }
            Console.WriteLine("\te.g. 1,3");
            string numbersDayInput = Console.ReadLine();
            string[] numberDayInputs = numbersDayInput.Split(',');

            var selectedFirstPartCodesList = new List<string>();
           
            foreach (string val in numberDayInputs)
            {
                var linkFirstPart = chooseDayList.Find(x => x.Id == val);
                selectedFirstPartCodesList.Add(linkFirstPart.Code);
            }
            return selectedFirstPartCodesList;

        }


        //static List<string> GenerateFirstPartLink(List<string> SelectedFirstPartCodeList, List<string> SelectedDaysList)
        //{
        //    Console.WriteLine("\tWrite numbers which days do you want to download:");
        //    var chooseDayList = new List<ChoosingProperties>
        //    {
        //         new ChoosingProperties("1", "cr/", "Today"),
        //         new ChoosingProperties("2","crdl/","Tomorrow"),
        //         new ChoosingProperties("3","crdl1/","Day After Tomorrow")
        //    };

        //    foreach (ChoosingProperties val in chooseDayList)
        //    {
        //        Console.WriteLine($"{val.Id} - {val.Name}");
        //    }
        //    Console.WriteLine("\te.g. 1,3");
        //    string numbersDayInput = Console.ReadLine();
        //    string[] numberDayInputs = numbersDayInput.Split(',');

        //    var selectedFirstPartCodesList = new List<string>();
        //    var selectedDaysList = new List<string>();

        //    foreach (string val in numberDayInputs)
        //    {
        //        var linkFirstPart = chooseDayList.Find(x => x.Id == val);
        //        selectedFirstPartCodesList.Add(linkFirstPart.Code);
        //        selectedDaysList.Add(linkFirstPart.Name);

        //    }
        //    return selectedFirstPartCodesList, selectedDaysList;

        //}




        public static List<string> GenerateSecondPartLink()
        {
            Console.WriteLine("\tWrite numbers which elements are you looking for");
            weatherPropertiesList = new List<ChoosingProperties> {
                new ChoosingProperties("1","oblcX","All Clouds"),
                new ChoosingProperties("2","srzk","Precipitation"),
                new ChoosingProperties("3","t2m","Temperature"),
                new ChoosingProperties("4","vitrx","Wind 10m"),
                new ChoosingProperties("5","vitry","Gust"),
                new ChoosingProperties("6","vitra","Wind 850 hPa"),
                new ChoosingProperties("7","vitrb","Wind 800 hPa"),
                new ChoosingProperties("8","drtr","Kind of Thermals"),
                new ChoosingProperties("9","cudf","Convective Temperature Deficit"),
                new ChoosingProperties("10","cukh","Cumulus Clouds"),
                new ChoosingProperties("11","cuvr","Climb Speed")
            };
            
            
            foreach (ChoosingProperties val in weatherPropertiesList)
            {
                Console.WriteLine($"{val.Id} - {val.Name}");
            }
            Console.WriteLine("\te.g. 1,2,5,8");

            string numbersWeatherPropertiesInput = Console.ReadLine();
            string[] numberWeatherPropetiesInputs = numbersWeatherPropertiesInput.Split(',');

            var selectedSecondPartCodesList = new List<string>();

            foreach (string val in numberWeatherPropetiesInputs)
            {
                var linkSecondPart = weatherPropertiesList.Find(x => x.Id == val);
                selectedSecondPartCodesList.Add(linkSecondPart.Code);

            }
            return selectedSecondPartCodesList;
        }

        static List<string> GenerateThirdPartLink()
        {

            Console.WriteLine("\tWhat time are you looking for?");
            Console.WriteLine("\te.g.   9,12,15,17");

            string numbersTimeInput = Console.ReadLine();
            string[] numberTimeInputs = numbersTimeInput.Split(",");

            var selectedThirdPartCodesList = new List<string>();

            foreach (string val in numberTimeInputs)
            {
                selectedThirdPartCodesList.Add(val);
            }
            return selectedThirdPartCodesList;

        }
        static void StartDownload()
        {
            string fileNameWeatherProperties, fileNameTime;
            foreach (string val in completeLinksList)
            {
                        fileNameTime = string.Concat(val.ToArray().Reverse().TakeWhile(char.IsNumber).Reverse());

                foreach (ChoosingProperties y in weatherPropertiesList)
                {
                    if (val.Contains(y.Code))
                    {
                        fileNameWeatherProperties = y.Name;
                        Console.WriteLine(fileNameWeatherProperties+fileNameTime);
                    }
                    
                }
                //Console.WriteLine($"{fileName}");
                //WebClient webClient = new WebClient();
                //webClient.DownloadFile(val, completePath + "\\" );          //nie dokończone
            }

        }
        static void GeneratorFileName()
        {
            Console.WriteLine("not working yet");
        }

            static List<string> GenerateCompleteLinks()
        {
            string mainLink = "http://flymet.meteopress.cz/";
            var selectedCompleateLinksList = new List<string>();

            foreach (string firstPartLink in firstPartLinks)
            {
                foreach (string secondPartLink in secondPartLinks)
                {
                    foreach (string thirdPartLink in thirdPartLinks)
                    {
                        string completeLink = $"{mainLink}{firstPartLink}{secondPartLink}{thirdPartLink}.png";
                        Console.WriteLine(completeLink);
                        selectedCompleateLinksList.Add(completeLink);
                    }
                }
                    
            }
            return selectedCompleateLinksList;

        }
        static void Confirmation()
        {
            Console.WriteLine("If you are sure press \"ENTER\"");

            if (Console.ReadKey().Key == ConsoleKey.Enter)             //o co tu chodzi?
            {
                GenerateCompleteLinks();
            }
            else
            {
                MainMenu();
            }
                
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
        static void GenerateAllProperties()
        {
            Console.WriteLine();
        }
        static void FileName()
        {

        }
    }
}
