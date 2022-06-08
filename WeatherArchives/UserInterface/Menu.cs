using Flymet;
using System;
using System.Collections.Generic;

namespace UserInterface
{
    public class Menu
    {
        public void UserInterface()
        {
            var display = new Display();
            var fileOperation = new FileOperation();
            
            display.MainMenu();

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    display.CaseMenuOptions(fileOperation, Values.regionFilePath, FlymetLinkParts.forecastRegions);
                    break;

                case "2":
                    display.CaseMenuOptions(fileOperation, Values.productFilePath, FlymetLinkParts.forecastProducts);
                    break;

                case "3":
                    display.CaseMenuOptions(fileOperation, Values.timeFilePath, FlymetLinkParts.ForecastTimes());
                    break;

                case "4":
                    display.CaseMenuGmail(fileOperation, Values.gmailFilePath);
                    break;

                case "5":
                    display.CaseMenuChoosenOptions(fileOperation);
                    break;

                case "c":
                    return;

                default:
                    break;
            }

            UserInterface();

      
        }



    }
}
