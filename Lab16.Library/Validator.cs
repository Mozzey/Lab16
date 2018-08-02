using System;
using System.Text.RegularExpressions;

namespace Lab16.Library
{
    public class Validator
    {
        public static bool ValidInput(string word)
        {
            var regx = new Regex(@"^([A-Za-z]+)\s?([A-Za-z]+)$");
            var validWord = regx.Match(word);
            return validWord.Success;
        }

        public static bool ValidInt(string number)
        {
            var regx = new Regex(@"\d");
            var validInt = regx.Match(number);
            return validInt.Success;
        }
    }
}
