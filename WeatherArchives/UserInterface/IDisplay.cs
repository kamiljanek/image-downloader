using Flymet.Entities;
using System.Collections.Generic;

namespace UserInterface
{
    public interface IDisplay
    {
        void MainMenu();
        void CaseMenuOptions(string filePath, List<FlymetUrlElement> forecastElements);
        void CaseMenuGmail();
        void CaseMenuChoosenOptions();

    }
}