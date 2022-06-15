using Flymet;
using System;
using System.Collections.Generic;
using System.IO;

namespace UserInterface
{
    public class Display
    {
        public void Title()
        {
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth - ConstantValue.pageAdress.Length) / 2, Console.CursorTop); //centering text
            Console.WriteLine(ConstantValue.pageAdress);

            Console.SetCursorPosition((Console.WindowWidth - ConstantValue.appTitle.Length) / 2, Console.CursorTop); //centering text
            Console.WriteLine(ConstantValue.appTitle);
            Console.WriteLine("");
        }
        public void MainMenu()
        {
            Title();
            Console.WriteLine($"1 - Forecast localization {ConstantValue.MainMenuEnds}");
            Console.WriteLine($"2 - Forecast type {ConstantValue.MainMenuEnds}");
            Console.WriteLine($"3 - Forecast hour {ConstantValue.MainMenuEnds} UTC");
            Console.WriteLine($"4 - Email settings...");
            Console.WriteLine($"5 - Check settings...");
            Console.WriteLine($"c - Close application...");
            Console.WriteLine("");
            Console.Write("Choose option: ");
        }
        /// <summary>
        /// Display menu of product with options to choose
        /// </summary>
        /// <param name="fileOperation">FileOperation instance</param>
        /// <param name="filePath">Name or whole path of file to create</param>
        /// <param name="forecastElements">List of all Url Elements to display in specific case</param>
        public void CaseMenuOptions(FileOperation fileOperation, string filePath, List<ForecastUrlElement> forecastElements)
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
        public void CaseMenuGmail(FileOperation fileOperation, string filePath)
        {
            Title();
            var gmailData = GetUserGmailData();
            fileOperation.FileGenerator(filePath, gmailData);
        }
        public void CaseMenuChoosenOptions(FileOperation fileOperation)
        {
            Title();
            DisplayChoosenOptions(fileOperation);
            Console.WriteLine("");
            Console.Write("To continue press ENTER...");
            Console.ReadKey();
        }

        private void DisplayChoosenOptions(FileOperation fileOperation)
        {
            try
            {
                DirectoryInfo d = new DirectoryInfo(Directory.GetCurrentDirectory()); //relative folder path
                FileInfo[] Files = d.GetFiles("UserSelection*"); //Getting all UserSelection files
                foreach (FileInfo file in Files)
                {
                    Console.WriteLine("");
                    var title = file.Name.Replace(".json", string.Empty).Replace("UserSelection_", string.Empty).ToUpper();
                    Console.WriteLine(title);
                    var elements = fileOperation.FileReader<ForecastUrlElement>(file.FullName);
                    foreach (var item in elements)
                    {
                        Console.Write($"{item.Name}, ");
                    }
                    Console.WriteLine("");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot find file. Error : " + ex);
            }

        }

        /// <summary>
        /// Display choosen menu with options
        /// </summary>
        /// <param name="forecastElements">Whole list of Url Elements</param>
        /// <returns>Return string with choosen elements by user</returns>
        public string DisplayChoosenMenu(List<ForecastUrlElement> forecastElements)
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
        private List<string> GetUserGmailData()
        {
            var gmailInput = new List<string>();

            Console.WriteLine("Input your Gmail address:");
            var userEmailAddress = Console.ReadLine();
            Console.WriteLine("Input your Gmail password:");
            var userEmailPassword = Console.ReadLine();
            gmailInput.Add(userEmailAddress);
            gmailInput.Add(userEmailPassword);

            return gmailInput;
        }

        /// <summary>
        /// Select Url Elements from user inputs
        /// </summary>
        /// <param name="urlElements">List of whole Url Elements</param>
        /// <param name="userInput">User input e.g. 1,3,6</param>
        /// <returns>Return lint of selected Url Elements</returns>
        private List<ForecastUrlElement> SelectUrlElements(List<ForecastUrlElement> urlElements, string userInput)
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
