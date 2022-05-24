using Engine;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace UserInterface
{
    public class Menu
    {

        public static void MainMenu()
        {
            Title();
            Console.WriteLine($"1 - Forecast localization {Values.MainMenuEnds}");
            Console.WriteLine($"2 - Forecast type {Values.MainMenuEnds}");
            Console.WriteLine($"3 - Forecast hour {Values.MainMenuEnds} UTC");
            Console.WriteLine($"4 - Email settings...");
            Console.WriteLine($"5 - Check settings...");
            Console.WriteLine($"c - Close application...");
            Console.WriteLine("");
            Console.Write("Choose option: ");

            var fileSetting = new FileSetting();
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    CaseMenu(fileSetting, FlymetData.forecastRegionsList, Values.regionFilePath);  
                    break;

                case "2":
                    CaseMenu(fileSetting, FlymetData.forecastProductsList, Values.productFilePath); 
                    break;

                case "3":
                    CaseMenu(fileSetting, FlymetData.ForecastTimesList(), Values.timeFilePath); 
                    break;

                case "4":
                    CaseMenu(fileSetting, UserEmailData(), Values.gmailFilePath);
                    break;

                case "5":
                    Title();
                    ShowChoosenSetting(fileSetting, "Regions:", Values.regionFilePath, UserElement.forecastDaysInput);
                    ShowChoosenSetting(fileSetting, "Products:", Values.productFilePath, UserElement.forecastTypesInput);
                    ShowChoosenSetting(fileSetting, "Times:", Values.timeFilePath, UserElement.forecastHoursInput);
                    Console.WriteLine("");
                    Console.Write("To continue press ENTER...");
                    Console.ReadKey();
                    break;

                case "c":
                    return;

                default:
                    break;
            }

            MainMenu();

        }

        private static List<string> UserEmailData()
        {
            Title();
            Console.WriteLine("Input your Gmail address:");
            var userEmailAddress = Console.ReadLine();
            Console.WriteLine("Input your Gmail password:");
            var userEmailPassword = Console.ReadLine();
            UserElement.gmailInput.Add(userEmailAddress);
            UserElement.gmailInput.Add(userEmailPassword);

            return UserElement.gmailInput;
        }

        private static void Title()
        {
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth - Values.pageAdress.Length) / 2, Console.CursorTop); //centering text
            Console.WriteLine(Values.pageAdress);

            Console.SetCursorPosition((Console.WindowWidth - Values.appTitle.Length) / 2, Console.CursorTop); //centering text
            Console.WriteLine(Values.appTitle);
            Console.WriteLine("");
        }
        private static void CaseMenu(FileSetting d, List<ForecastElement> forecastElements, string filePath)
        {
            Title();
            var userInput = ChoosenMenuView(forecastElements);
            var selectedItems = SelectedItemList(forecastElements, userInput);
            d.FileGenerator(filePath, selectedItems);
        }

        private static void CaseMenu(FileSetting d, List<string> gmailData, string filePath)
        {
            d.FileGenerator(filePath, gmailData);
        }
    
        private static void ShowChoosenSetting(FileSetting d, string nameOfSetting, string filePath, List<ForecastElement> selectedElements)
        {
            Console.WriteLine("");
            Console.WriteLine(nameOfSetting);
            var elements = d.FileReader<ForecastElement>(filePath);
            foreach (var item in elements)
            {
                Console.Write($"{item.Name}, ");
            }
            Console.WriteLine("");
        }

        public static string ChoosenMenuView(List<ForecastElement> forecastLists)
        {
            foreach (ForecastElement val in forecastLists)
            {
                Console.WriteLine($"{val.Id} - {val.Name}");
            }
            Console.WriteLine("");
            Console.WriteLine("You can input multiple numbers, for example: 1,2,3");
            Console.Write("Choose numbers: ");
            return Console.ReadLine();
        }

        private static List<ForecastElement> SelectedItemList(List<ForecastElement> forecastList, string userInput)
        {
            string[] userInputs = userInput.Split(',');

            var selectedItemsList = new List<ForecastElement>();

            foreach (string val in userInputs)
            {
                var selectedForecastDay = forecastList.Find(x => x.Id == val);
                selectedItemsList.Add(selectedForecastDay);
            }
            return selectedItemsList;
        } 
    }
}
