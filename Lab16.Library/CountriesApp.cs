using System;
using System.Collections.Generic;
using System.Text;

namespace Lab16.Library
{
    public class CountriesApp
    {
        public string Country { get; set; }

        /*public enum Option
        {
            None = 0,
            Read,
            Write,
            Quit
        }*/

        public void Menu()
        {
            Console.WriteLine("Please choose an option: ");
            var option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
            
        }

    }
}
