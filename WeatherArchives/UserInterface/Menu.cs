using Flymet;
using Model;
using System;

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
                    display.CaseMenuOptions(fileOperation, FlymetConstValue.RegionFilePath, FlymetData.forecastRegions);
                    break;

                case "2":
                    display.CaseMenuOptions(fileOperation, FlymetConstValue.ProductFilePath, FlymetData.forecastProducts);
                    break;

                case "3":
                    display.CaseMenuOptions(fileOperation, FlymetConstValue.TimeFilePath, FlymetData.ForecastTimes());
                    break;

                case "4":
                    display.CaseMenuGmail(fileOperation, ConstantValue.GmailFilePath);
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
