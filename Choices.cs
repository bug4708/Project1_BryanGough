using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure1
{
    internal class Choices
    {
        public static string Number(int optionNum)
        {
            string input = "";
            string options = "ABCD";
            while (!options.Substring(0, optionNum).Contains(input) || input.Length == 0 || input.Length != 1)
            {
                input = Console.ReadLine();
                input = input.ToUpper().Trim();
            }
            return input;
        }
    }
}
