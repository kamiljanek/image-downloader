using Flymet.Entities;
using Flymet.ManualData;
using Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace UserInterface
{
    public class Display : IDisplay
    {
        private readonly IFileOperation _fileOperation;
        private readonly IUserGmail _userGmail;

        public Display(IFileOperation fileOperation, IUserGmail userGmail)
        {
            _fileOperation = fileOperation;
            _userGmail = userGmail;
        }

        public void Title()
        {
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth - FlymetConstValue.PageAdress.Length) / 2, Console.CursorTop); //centering text
            Console.WriteLine(FlymetConstValue.PageAdress);

            Console.SetCursorPosition((Console.WindowWidth - ConstantValue.AppTitle.Length) / 2, Console.CursorTop); //centering text
            Console.WriteLine(ConstantValue.AppTitle);
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
        /// <param name="forecastElements">List of all URL Elements to display in specific case</param>
        public void CaseMenuOptions(string filePath, List<FlymetUrlElement> forecastElements)
        {
            Title();
            var userInput = DisplayChoosenMenu(forecastElements);
            var selectedItems = SelectUrlElements(forecastElements, userInput);
            _fileOperation.FileGenerator(filePath, selectedItems);
        }
        /// <summary>
        /// Display menu to input login and password of Gmail
        /// </summary>
        /// <param name="fileOperation">File Operation</param>
        /// <param name="filePath">Name or whole path of file to create</param>
        public void CaseMenuGmail()
        {
            Title();
            var gmailData = SetUserGmailData();
            _fileOperation.FileGenerator(ConstantValue.GmailFilePath, gmailData);
        }
        public void CaseMenuChoosenOptions()
        {
            Title();
            DisplayChoosenOptions();
            Console.WriteLine("");
            Console.Write("To continue press ENTER...");
            Console.ReadKey();
        }

        /// <summary>
        /// Display chosen menu with options
        /// </summary>
        /// <param name="flymetUrlElements">Whole list of URL Elements</param>
        /// <returns>Return string with chosen elements by user</returns>
        private string DisplayChoosenMenu(List<FlymetUrlElement> flymetUrlElements)
        {
            foreach (FlymetUrlElement val in flymetUrlElements)
            {
                Console.WriteLine($"{val.Id} - {val.Name}");
            }
            Console.WriteLine("");
            Console.WriteLine("You can input multiple numbers, for example: 1,2,3");
            Console.Write("Choose numbers: ");
            return Console.ReadLine();
        }
        private void DisplayChoosenOptions()
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
                    var elements = _fileOperation.FileReader<List<FlymetUrlElement>>(file.FullName);
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
        private IUserGmail SetUserGmailData()
        {
            Console.WriteLine("Input your Gmail address:");
            _userGmail.GmailAddress = Console.ReadLine();
            while (_userGmail.GmailAddress == null)
            {
                Console.WriteLine("Wrong address, try again:");
                _userGmail.GmailAddress = Console.ReadLine();
            }

            Console.WriteLine("Input your Gmail password:");
            _userGmail.GmailPassword = Console.ReadLine();
            while (_userGmail.GmailPassword == null)
            {
                Console.WriteLine("Wrong password, try again:");
                _userGmail.GmailPassword = Console.ReadLine();
            }

            return _userGmail;
        }
        /// <summary>
        /// Select URL Elements from user inputs
        /// </summary>
        /// <param name="urlElements">List of whole URL Elements</param>
        /// <param name="userInput">User input e.g. 1,3,6</param>
        /// <returns>Return list of selected URL Elements</returns>
        private List<FlymetUrlElement> SelectUrlElements(List<FlymetUrlElement> urlElements, string userInput)
        {
            string[] userInputs = userInput.Split(',');

            var selectedUrlElements = new List<FlymetUrlElement>();

            foreach (string val in userInputs)
            {
                var selectedForecastUrlElement = urlElements.Find(x => x.Id == val);
                selectedUrlElements.Add(selectedForecastUrlElement);
            }
            return selectedUrlElements;
        }
    }
}
