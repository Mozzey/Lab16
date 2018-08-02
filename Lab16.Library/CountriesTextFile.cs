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
            StreamReader sr = File.OpenText(PATH);
            Console.WriteLine(sr.ReadToEnd());
            sr.Close();
        }
        public void WriteToFile()
        {
            
            Console.Write("Please type in a country: ");
            var country = Console.ReadLine().ToLower();
            if (File.Exists(PATH))
            {
                StreamWriter sw = File.AppendText(PATH);
                sw.WriteLine(country);
                sw.Close();
            }
            else
            {
                StreamWriter sw = File.CreateText(PATH);
                sw.WriteLine(country);
                sw.Close();
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
                    if (line != userInput)
                    {
                        sw.WriteLine(line);
                    }
                }
            }
            File.Delete(PATH);
            File.Move(temp, PATH);
            
            
        }
    }
}
