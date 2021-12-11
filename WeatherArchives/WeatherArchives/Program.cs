using System;

namespace WeatherArchives
{
    class Program
    {
        static void Main(string[] args)
        {
            string title = "WEATHER ARCHIVES";

            Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop);
            Console.WriteLine(title);
            
            Console.WriteLine();
            
            Console.WriteLine("     Write day do you want to download?");
            
            Console.WriteLine(" 1 - for Today");
            Console.WriteLine(" 2 - for Tomorrow");
            Console.WriteLine(" 3 - for Day After Tomorrow");

            string day = Console.ReadLine();

            if(day == "1")
            {
                Console.WriteLine("You chose Today");
             
            }
            else if(day == "2")
            {
                Console.WriteLine("You chose Tomorrow");
            }
            else if(day == "3")
            {
                Console.WriteLine("You chose Day After Tomorrow");
            }
            else
            {
                Console.WriteLine("Wrong number! Choose number between 1, 2, 3");
            }

            
        }
    }
}
