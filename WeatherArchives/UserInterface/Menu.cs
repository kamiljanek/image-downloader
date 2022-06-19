using Flymet;
using Model;
using System;

namespace UserInterface
{
    public class Menu
    {
        private readonly IDisplay _display;

        public Menu(IDisplay display)
        {
            _display = display;
        }

        public void UserInterface()
        {
            _display.MainMenu();

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    _display.CaseMenuOptions(FlymetConstValue.RegionFilePath, FlymetData.forecastRegions);
                    break;

                case "2":
                    _display.CaseMenuOptions(FlymetConstValue.ProductFilePath, FlymetData.forecastProducts);
                    break;

                case "3":
                    _display.CaseMenuOptions(FlymetConstValue.TimeFilePath, FlymetData.ForecastTimes());
                    break;

                case "4":
                    _display.CaseMenuGmail(ConstantValue.GmailFilePath);
                    break;

                case "5":
                    _display.CaseMenuChoosenOptions();
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
