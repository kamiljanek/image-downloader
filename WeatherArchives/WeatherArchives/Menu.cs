using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WeatherArchives
{
    internal static class Menu
    {

        internal static void MainMenu()
        {
            Values.Title();
            Console.WriteLine($"1 - Forecast Days {Values.MainMenuEnds}");
            Console.WriteLine($"2 - Forecast Type {Values.MainMenuEnds}");
            Console.WriteLine($"3 - Forecast Hours {Values.MainMenuEnds}");
            Console.WriteLine($"4 - Create archive folder...");
            Console.WriteLine($"5 - Check settings...");
            Console.WriteLine($"6 - Save settings...");
            Console.WriteLine("");
            Console.Write("Choose option: ");

            Data data = new Data();
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    CaseMenu(data, ForecastLists.forecastDayList, Values.dayInputsFile);
                    break;

                case "2":
                    CaseMenu(data, ForecastLists.forecastTypeList, Values.typeInputsFile);
                    break;

                case "3":
                    Values.Title();
                    Console.WriteLine("Choose hours between 1-24 ...");
                    Console.WriteLine("For example: 9,12,15,17");
                    data.FileGenerator(Values.hourInputsFile, SelectedItemsList(ForecastLists.HourList()));
                    break;

                case "4":
                    CaseMenu(data, Values.archiveFile, FolderPathGenerator());
                    break;

                case "5":
                    Values.Title();
                    CheckSettings();
                    break;

                case "6":
                    ForecastLists.selectedForecastElements = ForecastLists.GenerateDownloadItems();
                    ForecastLists.completeURLList = ForecastLists.GeneratorURLs();
                    SaveSettings();
                    break;

                default:
                    Values.Title();
                    Console.WriteLine("WRONG CHOOISE!!! TRY ONE MORE TIME");
                    break;

            }
            MainMenu();

        }

        private static void CaseMenu(Data data, List<ForecastElement> forecastElements, string filePath)
        {
            Values.Title();
            ChoosenMenuView(forecastElements);
            data.FileGenerator(filePath, SelectedItemsList(forecastElements));
        }
        private static void CaseMenu(Data data, string filePath, string text)
        {
            Values.Title();
            data.FileGenerator(filePath, text);
        }
        private static void SaveSettings()
        {
            DataBase dataBase = new DataBase();
            dataBase.ModifyTables();
        }

        private static void CheckSettings()
        {
            Console.WriteLine("");
            Console.WriteLine("Days:");
            foreach (var item in ForecastLists.forecastDaysInput)
            {
                Console.Write($"{item.Name}, ");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Types:");
            foreach (var item in ForecastLists.forecastTypesInput)
            {
                Console.Write($"{item.Name}, ");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Hours:");
            foreach (var item in ForecastLists.forecastHoursInput)
            {
                Console.Write($"{item.Name}, ");
            }
            Console.WriteLine("");
            Console.WriteLine("To continue press ENTER...");
            Console.ReadKey();
        }

        internal static void ChoosenMenuView(List<ForecastElement> forecastLists)
        {

            foreach (ForecastElement val in forecastLists)
            {
                Console.WriteLine($"{val.Id} - {val.Name}");
            }

            Console.WriteLine("");
            Console.WriteLine("You can input multiple numbers, for example: 1,2,3");
            Console.Write("Choose numbers: ");


        }
        internal static List<ForecastElement> SelectedItemsList(List<ForecastElement> forecastList)
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
        static string FolderPathGenerator()
        {
            Console.Write("Folder name: ");
            var folderName = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Localization: ");
            var localizationOnComputer = Console.ReadLine();

            return $"{localizationOnComputer}\\{folderName}";
        }

    }
}
