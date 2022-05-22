using Engine;
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
            //Console.WriteLine($"4 - Create archive folder...");
            Console.WriteLine($"5 - Check settings...");
            Console.WriteLine($"6 - Email settings...");
            Console.WriteLine($"c - Close application...");
            Console.WriteLine("");
            Console.Write("Choose option: ");

            var fileSetting = new FileSetting();
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    CaseMenu(fileSetting, ForecastLists.forecastDaysList, Values.dayInputsFilePath);  
                    break;

                case "2":
                    CaseMenu(fileSetting, ForecastLists.forecastTypesList, Values.typeInputsFilePath); 
                    break;

                case "3":
                    Title();
                    Console.WriteLine("Choose hours between 1-24 ...");
                    Console.WriteLine("For example: 9,12,15,17 UTC");
                    fileSetting.FileGenerator(Values.hourInputsFilePath, SelectedItemList(ForecastLists.HoursList()));      //*.txt file generator
                    break;

                //case "4":
                //    Title();
                //    Values.folderPath = FolderPathGenerator();
                //    CaseMenu(fileSetting, Values.archiveFilePath, Values.folderPath);
                //    Directory.CreateDirectory(Values.folderPath);   //create new folder
                //    break;

                case "5":
                    Title();
                    ShowChoosenSetting(fileSetting, "Days:", Values.dayInputsFilePath, ForecastLists.forecastDaysInput);
                    ShowChoosenSetting(fileSetting, "Types:", Values.typeInputsFilePath, ForecastLists.forecastTypesInput);
                    ShowChoosenSetting(fileSetting, "Hours:", Values.hourInputsFilePath, ForecastLists.forecastHoursInput);
                    Console.WriteLine("");
                    Console.Write("To continue press ENTER...");
                    Console.ReadKey();
                    break;

                case "6":
                    CaseMenu(fileSetting, Values.emailInputsFilePath, UserEmailData());
                    break;

                case "c":
                    return;

                default:
                    break;
            }

            MainMenu();

        }

        private static string UserEmailData()
        {
            Title();
            Console.WriteLine("Input your Gmail address:");
            var userEmailAddress = Console.ReadLine();
            Console.WriteLine("Input your Gmail password:");
            var userEmailPassword = Console.ReadLine();

            return userEmailAddress + "\n" + userEmailPassword;
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
            ChoosenMenuView(forecastElements);
            d.FileGenerator(filePath, SelectedItemList(forecastElements));
        }

        private static void CaseMenu(FileSetting d, string filePath, string text)
        {
            d.FileGenerator(filePath, text);
        }
    
        private static void ShowChoosenSetting(FileSetting d, string nameOfSetting, string fileName, List<ForecastElement> selectedElements)
        {
            Console.WriteLine("");
            Console.WriteLine(nameOfSetting);
            var elements = d.FileReader(fileName, selectedElements);
            foreach (var item in elements)
            {
                Console.Write($"{item.Name}, ");
            }
            Console.WriteLine("");
        }

        public static void ChoosenMenuView(List<ForecastElement> forecastLists)
        {
            foreach (ForecastElement val in forecastLists)
            {
                Console.WriteLine($"{val.Id} - {val.Name}");
            }
            Console.WriteLine("");
            Console.WriteLine("You can input multiple numbers, for example: 1,2,3");
            Console.Write("Choose numbers: ");
        }

        private static List<ForecastElement> SelectedItemList(List<ForecastElement> forecastList)
        {
            string userInput = Console.ReadLine();
            string[] userInputs = userInput.Split(',');

            var selectedItemsList = new List<ForecastElement>();

            foreach (string val in userInputs)
            {
                var selectedForecastDay = forecastList.Find(x => x.Id == val);
                selectedItemsList.Add(selectedForecastDay);
            }
            return selectedItemsList;
        }

        private static string FolderPathGenerator()
        {
            Console.Write("Folder name: ");
            var folderName = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Localization: ");
            var localizationOnComputer = Console.ReadLine();
            localizationOnComputer = localizationOnComputer.RemoveLastCharIfItIs('\\', '/').Replace("\"", string.Empty);
            return $"{localizationOnComputer}\\{folderName}";
        }
  
    }
}
