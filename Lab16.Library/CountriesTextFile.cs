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
            if (File.Exists(PATH))
            {
                StreamReader sr = File.OpenText(PATH);
                Console.WriteLine("=================================================");
                Console.WriteLine(sr.ReadToEnd());
                sr.Close();
            }
            else
            {
                Console.WriteLine("Sorry there are no countries on the list. Please add on to get started!");
            }
        }
        public void WriteToFile()
        {
            
            Console.Write("Please type in a country: ");
            var country = Console.ReadLine();
            if (Validator.ValidInput(country))
            {
                if (File.Exists(PATH))
                {
                    StreamWriter sw = File.AppendText(PATH);
                    sw.WriteLine(country);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{country} has been saved to the list!");
                    sw.Close();
                }
                else
                {
                    StreamWriter sw = File.CreateText(PATH);
                    sw.WriteLine(country);
                    sw.Close();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid country name - ex: \"Country\" or \"Country Name\"");
            }
            

        }

        public void DeleteFromFile()
        {
            Console.Write("Please type in a country to be deleted: ");
            var userInput = Console.ReadLine();
            var temp = Path.GetTempFileName();
            using (var sr = new StreamReader(PATH))
            using(var sw = new StreamWriter(temp))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.ToLower() != userInput)
                    {
                        sw.WriteLine(line);
                    }
                }
            }
            File.Delete(PATH);
            File.Move(temp, PATH);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{userInput} has been deleted from the list!");


        }
    }
}
