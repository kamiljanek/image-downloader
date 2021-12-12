using System;
using System.Text.RegularExpressions;
using System.Net;


namespace WeatherArchives
{
    class Program
    {
        public static string linkSecondPart; //why this should be here instead of 3 lines below????
        static void Main(string[] args)
        {
            string title = "WEATHER ARCHIVES";
            string pageAdress = "http://flymet.meteopress.cz/";
            string enter = "";
            string linkFirstPart = "http://flymet.meteopress.cz/";
            //string linkSecondPart;
            string linkToday = "cr/";
            string linkTomorrow = "crdl/";
            const string linkDayAfterTomorrow = "crdl1/"; //what is the diference compare to prewious one???
            var element = (allClouds: "oblcX", precipitation: "srzk", temp: "t2m", wind10m: "vitrx", gusts: "vitry", wind850hPa: "vitra", wind800hPa: "vitrb", 
                kindOfThermals: "drtr", convTempDeficit: "cudf", cumulusClouds: "cukh", climbSpeed: "cuvr"); //why I can't use string variable???

            Console.SetCursorPosition((Console.WindowWidth - pageAdress.Length) / 2, Console.CursorTop); //centering text
            Console.WriteLine(pageAdress);

            Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop); //centering text
            Console.WriteLine(title);

            Console.WriteLine(enter);

            Console.WriteLine("\tWrite day do you want to download?");

            var chooseDay = "1 - for Today\r\n2 - for Tomorrow\r\n3 - for Day After Tomorrow";

            Console.WriteLine(chooseDay);
           
            string day = Console.ReadLine();

            if (day == "1")
            {
                
                Console.WriteLine("You chose Today");
                linkSecondPart = linkToday;
            }
            else if (day == "2")
            {
                Console.WriteLine("You chose Tomorrow");
                linkSecondPart = linkTomorrow;
            }
            else if (day == "3")
            {
                Console.WriteLine("You chose Day After Tomorrow");
                linkSecondPart = linkDayAfterTomorrow;        
            }
            else
            {
                Console.WriteLine("Wrong number! Choose number between 1, 2, 3"); 
                //need to create exceptions for incorect number to string linkSecondPart
            }

            Console.WriteLine("\tWrite numbers which elements are you looking for");
            var chooseElement = "1 - All Clouds\r\n2 - Precipitation\r\n3 - Temperature\r\n4 - Wind 10m\r\n5 - Gusts" +
                "\r\n6 - Wind 850 hPa\r\n7 - Wind 800 hPa\r\n8 - Kind Of Thermals\r\n9 - Convective Temperature Deficit\r\n10 - Cumulus Clouds\r\n11 - Climb Speed";
            Console.WriteLine(chooseElement);
            //do not forget to create wind,temp, rain etc CHOOSE!!!

            string elementInput = Console.ReadLine();
            string[] numberElementInput = Regex.Split(elementInput, @"\D+");

            //string[] numberElementInputReplace = { numberElementInput,  };




            Console.WriteLine("\tWhich hours are you looking for?");
            Console.WriteLine("\te.g.   9,12,15,17");
            
            string hoursInput = Console.ReadLine();

            string[] numbersHoursInput = Regex.Split(hoursInput, @"\D+"); //create table


            foreach (string value in numbersHoursInput) //loop
            {
                if (!string.IsNullOrEmpty(value))
                {
                    int i = int.Parse(value);
                    Console.WriteLine("Number: {0}", i);
                    string hour = i.ToString();
                       
                    string fileName = @"C:\Users\JoHaNek\Desktop\archiwum\" + hour + ".png";
                    Console.WriteLine(fileName);
                    string link = linkFirstPart + linkSecondPart + hour + ".png";
                    Console.WriteLine(link);
                    WebClient webClient = new WebClient();
                    webClient.DownloadFile(link, fileName);
                }

            }
         
        }
    }
}
