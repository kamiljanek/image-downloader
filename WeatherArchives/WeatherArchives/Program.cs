using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace WeatherArchives
{
    class Program
    {
        
            private static string linkFirstPart = "http://flymet.meteopress.cz/";
        static void Main(string[] args)
        {
            
            const string localArchivePath = "C:\\Users\\JoHaNek\\Desktop\\archiwum\\";
            string linkSecondPart = string.Empty;

            ChooseDayMenu();

            Title();
            MainMenu();
    
 
            //string elementInput = Console.ReadLine();
            //string[] numberElementInputs = elementInput.Split(',');
            
            //weatherPropertiesList.Find(ChoosingProperty=>ChoosingProperty.Id==numberElementInputs).Code;
            //string[] numberElementInputReplace = { numberElementInput,  };




            Console.WriteLine("\tWhich hours are you looking for?");
            Console.WriteLine("\te.g.   9,12,15,17");
            
            string hoursInput = Console.ReadLine();
            string[] numbersHoursInput = hoursInput.Split(",");
            //string[] numbersHoursInput = Regex.Split(hoursInput, @"\D+"); //create table


            foreach (string value in numbersHoursInput) 
            {
                if (!string.IsNullOrEmpty(value))
                {
                    int i = int.Parse(value);
                    Console.WriteLine($"Number: {i}");
                    string hour = i.ToString();
                       
                    string fileName = $"{localArchivePath}{hour}.png";
                    Console.WriteLine(fileName);
                    string link = linkFirstPart + linkSecondPart + hour + ".png";
                    Console.WriteLine(link);
                    WebClient webClient = new WebClient();
                    //webClient.DownloadFile(link, fileName);
                                                           
                }

            }
         
        }
        //public class ChoosingProperties
        //{
        //    public ChoosingProperties(int id, string code, string name)
        //    {
        //        Id = id;
        //        Name = name;
        //        Code = code;
        //    }

        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //    public string Code { get; set; }
           
        //}
         
        static void Title()
        {
            string enter = "";
            string title = "WEATHER ARCHIVES";
            string pageAdress = "http://flymet.meteopress.cz/";
            Console.SetCursorPosition((Console.WindowWidth - pageAdress.Length) / 2, Console.CursorTop); //centering text
            Console.WriteLine(pageAdress);

            Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop); //centering text
            Console.WriteLine(title);
            Console.WriteLine(enter);
        }
        static void ClearWindow()
        {
            Console.Clear();
            Title();
        }
        static void MainMenu()
        {
            Console.WriteLine("1. Day?");
            Console.WriteLine("2. Type of Data?");
            Console.WriteLine("3. Time?");
            Console.WriteLine("4. Start Download");

            string opcionInput = Console.ReadLine();
            if (opcionInput == "1")
            {
                ClearWindow();
                ChooseDayMenu();
            }
            else if (opcionInput == "2")
            {
                ClearWindow();
                ChooseWeatherProperties();
            }
            else if (opcionInput == "3")
            {
                ClearWindow();
                ChooseTime();
            }
            else if (opcionInput == "4")
            {
                ClearWindow();
                StartDownload();
            }

            else
            {
                ClearWindow();
                Console.WriteLine("WRONG CHOOISE!!! TRY ONE MORE TIME");
                MainMenu();
            }
        }
        static void ChooseDayMenu()
        {
            //Console.WriteLine("\tType day are you intrested in?");
            //var chooseDayList = new List<ChoosingProperties>() {
            //    new ChoosingProperties(1,"cr/","Today"),
            //    new ChoosingProperties(2,"crdl/","Tomorrow"),
            //    new ChoosingProperties(3,"crdl1/","Day After Tomorrow")
            //};

            List<ChoosingProperties> chooseDayList = new List<ChoosingProperties>();
            chooseDayList.Add(new ChoosingProperties() { Id = 1, Code = "cr/", Name = "Today" });
            chooseDayList.Add(new ChoosingProperties() { Id = 2, Code = "crdl/", Name = "Tomorrow" });
            chooseDayList.Add(new ChoosingProperties() { Id = 3, Code = "crdl1/", Name = "Day After Tomorrow" });

            foreach (ChoosingProperties val in chooseDayList)
            {
                Console.WriteLine($"{val.Id} - {val.Name}");
            }
            string numbersDayInput = Console.ReadLine();
            string[] numberDayInputs = numbersDayInput.Split(',');

            //Console.WriteLine(chooseDayList.Find(x => x.Id.Contains($"{numberDayInputs}")));
            //foreach (ChoosingProperties val in chooseDayList)
            //{
            //    Console.WriteLine($"{val.Id} - {val.Name}");
            //}
            //Console.WriteLine("e.g. 1,2");

            //string numbersDayInput = Console.ReadLine();
            //string[] numberDayInputs = numbersDayInput.Split(',');

            //Console.WriteLine();
            // chooseDayList.Find(chooseDayList => chooseDayList.Id == numberDayInput).Code;
            //string[] numberElementInputReplace = { numberElementInput,  };
           
        }
       
        static void ChooseWeatherProperties()
        {
            Console.WriteLine("\tWrite numbers which elements are you looking for");
            //var weatherPropertiesList = new List<ChoosingProperties>() {
            //    new ChoosingProperties(1,"oblcX","All Clouds"),
            //    new ChoosingProperties(2,"srzk","Precipitation"),
            //    new ChoosingProperties(3,"t2m","Temperature"),
            //    new ChoosingProperties(4,"vitrx","Wind 10m"),
            //    new ChoosingProperties(5,"vitry","Gust"),
            //    new ChoosingProperties(6,"vitra","Wind 850 hPa"),
            //    new ChoosingProperties(7,"vitrb","Wind 800 hPa"),
            //    new ChoosingProperties(8,"drtr","Kind of Thermals"),
            //    new ChoosingProperties(9,"cudf","Convective Temperature Deficit"),
            //    new ChoosingProperties(10,"cukh","Cumulus Clouds"),
            //    new ChoosingProperties(11,"cuvr","Climb Speed")
            //};
            //foreach (ChoosingProperties val in weatherPropertiesList)
            //{
            //    Console.WriteLine($"{val.Id} - {val.Name}");
            //}
            Console.WriteLine("e.g. 1,2,5,8");

            string numbersWeatherPropertiesInput = Console.ReadLine();
            string[] numberWeatherPropetiesInputs = numbersWeatherPropertiesInput.Split(',');
        }

        static void ChooseTime()
        {

            Console.WriteLine("\tWhat time are you looking for?");
            Console.WriteLine("\te.g.   9,12,15,17");

            string numbersTimeInput = Console.ReadLine();
            string[] numberTimeInputs = numbersTimeInput.Split(",");
            

        }
        static void StartDownload()
        {

          
        }
        //public class Parachute
        //{
        //    public Parachute()
        //    {

        //    }
        //    public Parachute(int hexColour)
        //    {
        //        HexColour = hexColour;
        //    }
        //    public int HexColour { get; set; } = 0;
        //    public bool Open()
        //    {
        //        return false;
        //    }
        //    public bool Open(bool properPool)
        //    {
        //        return properPool;
        //    }
        //    public bool Open(string logo)
        //    {
        //        return false;
        //    }

        //}
    }
}
