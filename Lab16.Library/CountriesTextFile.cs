using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab16.Library
{
    public class CountriesTextFile
    {
        // store the path to the file location in a constant
        public const string PATH = @"C:\Users\Mozzey\GrandCircus\Labs\Lab16\Lab16.Library\countries.txt";
        // method to read from the .txt file
        public void ReadFromFile()
        {
            // check if the file exists already
            if (File.Exists(PATH))
            {
                // if file exists open it
                StreamReader sr = File.OpenText(PATH);
                Console.WriteLine("=================================================");
                // write the entire .txt file to the console
                Console.WriteLine(sr.ReadToEnd());
                // close the stream
                sr.Close();
            }
            else
            {
                // no list exists - use WriteToFile method to create a new list
                Console.WriteLine("Sorry but no list has been created yet. Please add on to get started!");
            }
        }
        // method to write to the .txt file
        public void WriteToFile()
        {
            // ask for and store user input
            Console.Write("Please type in a country: ");
            var country = Console.ReadLine();
            // validate user input with regx from Validator class
            if (Validator.ValidInput(country))
            {
                // check if the file already exists
                if (File.Exists(PATH))
                {
                    // if file exists append/add to the current file
                    StreamWriter sw = File.AppendText(PATH);
                    sw.WriteLine(country);
                    Console.ForegroundColor = ConsoleColor.Green;
                    // let the user know the country has been added
                    Console.WriteLine($"{country} has been saved to the list!");
                    // close the stream
                    sw.Close();
                }
                else
                {
                    // if file doesnt exist create a new one at the 
                    // specified path and write the country to 
                    // a new .txt file
                    StreamWriter sw = File.CreateText(PATH);
                    sw.WriteLine(country);
                    // close stream
                    sw.Close();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid country name - ex: \"Country\" or \"Country Name\"");
            }
            

        }
        // method to delete a country from the .txt file
        public void DeleteFromFile()
        {
            // ask for and store user input
            Console.Write("Please type in a country to be deleted: ");
            var userInput = Console.ReadLine();
            // create a temp file to store and return the path of that file
            var temp = Path.GetTempFileName();
            // create a new StreamReader for the specified path
            using (var sr = new StreamReader(PATH))
            // create a StreamWriter for the temp path
            using (var sw = new StreamWriter(temp))
            {
                // define a string to hold the data
                string line;
                // check if the original file is empty as not to throw an error
                while ((line = sr.ReadLine()) != null)
                {
                    // check if user input is equal to a line in the .txt file
                    if (line.ToLower() != userInput)
                    {
                        // write all lines that done match user
                        // input to the temp file
                        sw.WriteLine(line);
                    }
                }
            }
            // delete the current .txt with original contents
            File.Delete(PATH);
            // Move the temp file without the matched user input
            // into the path of the original .txt
            File.Move(temp, PATH);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{userInput} has been deleted from the list!");


        }
    }
}
