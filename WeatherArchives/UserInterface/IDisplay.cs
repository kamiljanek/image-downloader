using Flymet;
using System.Collections.Generic;

namespace UserInterface
{
    public interface IDisplay
    {
        void MainMenu();
        void CaseMenuOptions(string filePath, List<FlymetForecastUrlElement> forecastElements);
        void CaseMenuGmail(string filePath);
        void CaseMenuChoosenOptions();



    }
}