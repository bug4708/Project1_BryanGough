using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure1
{
    internal class Choices
    {
        public static string Number(int optionNum)
        {
            //selects choices in a,b,c,d from indices 0,1... and changes them to uppercase,
            //also checks if the input is valid
            string input = "";
            string options = "ABCD";
            while (!options[..optionNum].Contains(input) || input.Length == 0 || input.Length != 1)
            {
                input = Console.ReadLine()!;
                input = input.ToUpper().Trim();
            }
            return input;
        }
    }
}
