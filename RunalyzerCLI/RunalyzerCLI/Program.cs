using System;
using RunalyzerCLI.Model;

namespace RunalyzerCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            sportsdirectorsystemContext context = new sportsdirectorsystemContext();

            string username;

            Console.WriteLine("Email address for Runalyzer:");
            username = Console.ReadLine();

            Console.Clear();

            Console.WriteLine($"Welcome to Runalyzer CLI! Feel free to take a service from the list below!");
            Console.WriteLine();

            Console.WriteLine($"1 - Overall stats for a race");
            Console.WriteLine($"2 - My stats for a race");

            int service = int.Parse(Console.ReadKey().ToString());       

            Console.ReadKey();
        }
    }
}
