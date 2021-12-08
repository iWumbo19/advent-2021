using System;
using System.Collections.Generic;

namespace advent_day8
{
    class Day8
    {
        static void Main(string[] args)
        {
            List<string> initialSplit = new List<string>();
            foreach (string line in System.IO.File.ReadLines("day8-input")) { initialSplit.Add(line.Split('|')[1]); }
            //foreach (string item in initialSplit) { Console.WriteLine(item); }
            int counter = 0;
            foreach (string item in initialSplit)
            {
                foreach (string digit in item.Split())
                {
                    if (digit.Length == 2 ^
                        digit.Length == 4 ^
                        digit.Length == 3 ^ 
                        digit.Length == 7)
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);         

        }
    }
}
