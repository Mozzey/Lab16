using System;
using System.Collections.Generic;
using System.Text;

namespace Lab16.Library
{
    public class CountriesApp
    {
        public void Menu(bool isRunning)
        {
            while (isRunning)
            {
                var menu = String.Format("{0}\n{1}\n{2}\n{3}\n{4}",
                    "Welcome to the Countries Maintenance App!",
                    "1 - See the list of countries",
                    "2 - Add a country",
                    "3 - Remove a country",
                    "4 - Quit");
                var textFile = new CountriesTextFile();
                Console.WriteLine(menu);
                Console.WriteLine("Please choose an option: ");
                var option = int.Parse(Console.ReadLine());
                if (option == (int) MenuOptions.Read)
                {
                    textFile.ReadFromFile();
                }
                else if (option == (int) MenuOptions.Write)
                {
                    textFile.WriteToFile();
                }
                else if (option == (int) MenuOptions.Delete)
                {
                    textFile.DeleteFromFile();
                }
                else if (option == (int)MenuOptions.Quit)
                {
                    Console.WriteLine("Buh-bye now!");
                    isRunning = false;
                }
            }
        }

    }
}
