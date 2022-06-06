using Flymet;
using System;
using System.Collections.Generic;

namespace UserInterface
{
    public class Menu
    {

        public static void MainMenu()
        {
            Display.Title();
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
                    Display.CaseMenuOptions(fileOperation, FlymetData.forecastRegionsList, Values.regionFilePath);
                    break;

                case "2":
                    Display.CaseMenuOptions(fileOperation, FlymetData.forecastProductsList, Values.productFilePath);
                    break;

                case "3":
                    Display.CaseMenuOptions(fileOperation, FlymetData.ForecastTimesList(), Values.timeFilePath);
                    break;

                case "4":
                    Display.CaseMenuGmail(fileOperation, Values.gmailFilePath);
                    break;

                case "5":
                    Display.CaseMenuShowChoosenOptions(fileOperation);
                    break;

                case "c":
                    return;

                default:
                    break;
            }

            MainMenu();

        }



    }
}
