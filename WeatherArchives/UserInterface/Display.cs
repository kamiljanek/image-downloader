using Flymet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface
{
    public class Display
    {
        public static void Title()
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
        public static void CaseMenuOptions(FileOperation fileOperation, List<ForecastUrlElement> forecastElements, string filePath)
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
        public static void CaseMenuGmail(FileOperation fileOperation, string filePath)
        {
            Title();
            var gmailData = GetUserGmailData();
            fileOperation.FileGenerator(filePath, gmailData);
        }
        public static void CaseMenuShowChoosenOptions(FileOperation fileOperation)
        {
            Title();
            DisplayChoosenOptions(fileOperation);
            Console.WriteLine("");
            Console.Write("To continue press ENTER...");
            Console.ReadKey();
        }

        public static void DisplayChoosenOptions(FileOperation fileOperation)
        {
            try
            {          
                DirectoryInfo d = new DirectoryInfo(Directory.GetCurrentDirectory()); //relative folder path
                FileInfo[] Files = d.GetFiles("UserSelection*"); //Getting all image files
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
