using System;
using System.Collections.Generic;
using System.Text;

namespace Lab16.Library
{
    public class CountriesApp
    {
        public void Menu(bool isRunning)
        {
            // main loop to keep the program running
            while (isRunning)
            {
                Console.ForegroundColor = ConsoleColor.White;
                var menu = String.Format("{0}\n{1}\n{2}\n{3}\n{4}",
                    "Welcome to the Countries Maintenance App!",
                    "1 - See the list of countries",
                    "2 - Add a country",
                    "3 - Remove a country",
                    "4 - Quit");
                // instantiate a new CountriesTextFile to access its functionality
                var textFile = new CountriesTextFile();
                // display menu
                Console.WriteLine(menu);
                // ask for and store user input
                Console.WriteLine("Please choose an option: ");
                var option = Console.ReadLine();
                // make sure user inputs valid number within range
                if (int.TryParse(option, out int validOption) && (validOption > 0 && validOption < 5))
                {
                    // if valid compare user input to enum options
                    // and perform corresponding method
                    if (validOption == (int)MenuOptions.Read)
                    {
                        textFile.ReadFromFile();
                    }
                    else if (validOption == (int)MenuOptions.Write)
                    {
                        textFile.WriteToFile();
                    }
                    else if (validOption == (int)MenuOptions.Delete)
                    {
                        textFile.DeleteFromFile();
                    }
                    else if (validOption == (int)MenuOptions.Quit)
                    {
                        Console.WriteLine("Buh-bye now!");
                        isRunning = false;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please choose an option from the menu");
                }
            }
        }

    }
}
