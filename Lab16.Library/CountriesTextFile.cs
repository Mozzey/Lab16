using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab16.Library
{
    public class CountriesTextFile
    {
        public const string PATH = @"C:\Users\Mozzey\GrandCircus\Labs\Lab16\Lab16.Library\countries.txt";

        public void ReadFromFile()
        {
            using (var reader = new StreamReader(PATH))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    Console.WriteLine(line);
                    /*if (line.IndexOf(country, StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        Console.WriteLine(line);
                    }*/
                }
            }
        }

        public void WriteToFile()
        {
            
            Console.Write("Please type in a country: ");
            var country = Console.ReadLine();
            using (var writer = new StreamWriter(PATH, true))
            {
                writer.WriteLine(country);
            }
        }

        public void DeleteFromFile()
        {
            using (var reader = new StreamReader(PATH))
            {
                Console.Write("Please type in a country to delete: ");
                var input = Console.ReadLine();
                while (!reader.EndOfStream)
                {
                    string pattern = @"[A-Za-z]";
                    string replacement = "";
                    var line = reader.ReadLine();
                    Regex regex = new Regex(pattern);
                    
                    if (line.IndexOf(input ?? throw new InvalidOperationException(), StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        string result = pattern.Replace(input, replacement);

                        
                    }
                }
            }
        }
    }
}
