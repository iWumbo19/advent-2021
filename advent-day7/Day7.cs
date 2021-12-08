using System;
using System.Linq;
using System.Collections.Generic;

namespace advent_day7
{
    class Day7
    {
        static void Main(string[] args)
        {
            string inputRaw = System.IO.File.ReadLines("day7-input").First();
            string[] input = inputRaw.Split(',');
            List<int> crabSubs = new List<int>();
            Array.ForEach(input, x => crabSubs.Add(int.Parse(x)));
            int minX = crabSubs.Min();
            int maxX = crabSubs.Max();
            long leastFuel = 1211330213;
            int currentBestIndex = -1;

            
            //Between the values of the smallest position to the biggest position
            for (int x = minX; x < maxX; x++)
            {
                int totalFuel = 0;
                //For Every Single Crab!
                for (int index = 0; index < crabSubs.Count; index++)
                {
                    if (x > crabSubs[index]) 
                    { 
                        int diff = (x - crabSubs[index]);
                        for (int a = 1; a <= diff; a++)
                        {
                            totalFuel += a;
                        }
                    }
                    else if (x < crabSubs[index])
                    { 
                        int diff = (crabSubs[index] - x);
                        for (int a = 1; a <= diff; a++)
                        {
                            totalFuel += a;
                        }
                    }
                }
                if (totalFuel < leastFuel)
                {
                    leastFuel = totalFuel;
                    currentBestIndex = x;
                }
                Console.WriteLine($"Position {x}: {totalFuel}");
            }
            Console.WriteLine($"Position {currentBestIndex}: {leastFuel}");
        }
    }
}
