using System;
using System.Text.RegularExpressions;

namespace WeatherArchives
{
    class Program
    {
        static void Main(string[] args)
        {
            string title = "WEATHER ARCHIVES";
            string pageAdress = "http://flymet.meteopress.cz/";
            string enter = "";


            Console.SetCursorPosition((Console.WindowWidth - pageAdress.Length) / 2, Console.CursorTop); //centering text
            Console.WriteLine(pageAdress);

            Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop); //centering text
            Console.WriteLine(title);

            Console.WriteLine(enter);

            Console.WriteLine("     Write day do you want to download?");

            Console.WriteLine(" 1 - for Today");
            Console.WriteLine(" 2 - for Tomorrow");
            Console.WriteLine(" 3 - for Day After Tomorrow");

            string day = Console.ReadLine();

            if (day == "1")
            {
                Console.WriteLine("You chose Today");

            }
            else if (day == "2")
            {
                Console.WriteLine("You chose Tomorrow");
            }
            else if (day == "3")
            {
                Console.WriteLine("You chose Day After Tomorrow");
            }
            else
            {
                Console.WriteLine("Wrong number! Choose number between 1, 2, 3");
            }

            Console.WriteLine("     Which hours are you looking for?");
            Console.WriteLine("     e.g.   9,12,15,17");

            string hours = Console.ReadLine();

            string[] numbers = Regex.Split(hours, @"\D+"); //create table

            foreach (string value in numbers)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    int i = int.Parse(value);
                    Console.WriteLine("Number: {0}", i);
                   
                }
            }
        }
    }
}
