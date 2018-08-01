using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab16.Library;

namespace Lab16
{
    class Program
    {
        static void Main(string[] args)
        {
            var countriesTextFile = new CountriesTextFile();
            countriesTextFile.DeleteFromFile();

            Console.ReadLine();
        }
    }
}
