using Flymet;
using System;
using System.Collections.Generic;

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

            var fileOperation = new FileOperation();
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    CaseMenuOptions(fileOperation, FlymetData.forecastRegionsList, Values.regionFilePath);
                    break;

                case "2":
                    CaseMenuOptions(fileOperation, FlymetData.forecastProductsList, Values.productFilePath);
                    break;

                case "3":
                    CaseMenuOptions(fileOperation, FlymetData.ForecastTimesList(), Values.timeFilePath);
                    break;

                case "4":
                    CaseMenuGmail(fileOperation, Values.gmailFilePath);
                    break;

                case "5":
                    Title();
                    DisplayChoosenOptions(fileOperation, "Regions:", Values.regionFilePath);
                    DisplayChoosenOptions(fileOperation, "Products:", Values.productFilePath);
                    DisplayChoosenOptions(fileOperation, "Times:", Values.timeFilePath);
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

        private static List<string> GetUserGmailData()
        {
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
        /// <summary>
        /// Display menu of product with options to choose
        /// </summary>
        /// <param name="fileOperation">FileOperation instance</param>
        /// <param name="forecastElements">List of all Url Elements to display in specific case</param>
        /// <param name="filePath">Name or whole path of file to create</param>
        private static void CaseMenuOptions(FileOperation fileOperation, List<ForecastUrlElement> forecastElements, string filePath)
        {
            Title();
            var userInput = DisplayChoosenMenu(forecastElements);
            var selectedItems = SelectUrlElements(forecastElements, userInput);
            fileOperation.FileGenerator(filePath, selectedItems);
        }
        /// <summary>
        /// Display menu to input login and password of Gmail
        /// </summary>
        /// <param name="fileOperation">File Operation</param>
        /// <param name="filePath">Name or whole path of file to create</param>
        private static void CaseMenuGmail(FileOperation fileOperation, string filePath)
        {
            Title();
            var gmailData = GetUserGmailData();
            fileOperation.FileGenerator(filePath, gmailData);
        }
        /// <summary>
        /// Display one part of options chosed by user
        /// </summary>
        /// <param name="fileOperation">File Operation</param>
        /// <param name="nameOfOptions">Title of options</param>
        /// <param name="filePath">Name or whole path of file with settings</param>
        private static void DisplayChoosenOptions(FileOperation fileOperation, string nameOfOptions, string filePath)
        {
            Console.WriteLine("");
            Console.WriteLine(nameOfOptions);
            var elements = fileOperation.FileReader<ForecastUrlElement>(filePath);
            foreach (var item in elements)
            {
                Console.Write($"{item.Name}, ");
            }
            Console.WriteLine("");
        }
        /// <summary>
        /// Display choosen menu with options
        /// </summary>
        /// <param name="forecastElements">Whole list of Url Elements</param>
        /// <returns>Return string with choosen elements by user</returns>
        public static string DisplayChoosenMenu(List<ForecastUrlElement> forecastElements)
        {
            foreach (ForecastUrlElement val in forecastElements)
            {
                Console.WriteLine($"{val.Id} - {val.Name}");
            }
            Console.WriteLine("");
            Console.WriteLine("You can input multiple numbers, for example: 1,2,3");
            Console.Write("Choose numbers: ");
            return Console.ReadLine();
        }
        /// <summary>
        /// Select Url Elements from user inputs
        /// </summary>
        /// <param name="urlElements">List of whole Url Elements</param>
        /// <param name="userInput">User input e.g. 1,3,6</param>
        /// <returns>Return lint of selected Url Elements</returns>
        private static List<ForecastUrlElement> SelectUrlElements(List<ForecastUrlElement> urlElements, string userInput)
        {
            string[] userInputs = userInput.Split(',');

            var selectedUrlElements = new List<ForecastUrlElement>();

            foreach (string val in userInputs)
            {
                var selectedForecastUrlElement = urlElements.Find(x => x.Id == val);
                selectedUrlElements.Add(selectedForecastUrlElement);
            }
            return selectedUrlElements;
        }
    }
}
