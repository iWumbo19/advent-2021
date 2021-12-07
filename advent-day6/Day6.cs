using System;
using System.Collections.Generic;
using System.Linq;

namespace advent_day6
{
    class Day6
    {
        static void Main(string[] args)
        {
            List<int> initialFish = new List<int>();
            string firstLine = System.IO.File.ReadLines("day6-input").First();
            string[] fish = firstLine.Split(',');
            foreach (var item in fish)
            {
                initialFish.Add(int.Parse(item));
            }
            for (int days = 0; days < 80; days++)
            {
                int fishNeeded = 0;
                for (int fishIndex = 0; fishIndex < initialFish.Count; fishIndex++)
                {
                    if (initialFish[fishIndex] == 0)
                    {
                        initialFish[fishIndex] = 6;
                        fishNeeded++;
                    }
                    else { initialFish[fishIndex]--; }
                }
                for (int newFish = 0; newFish < fishNeeded; newFish++)
                {
                    initialFish.Add(8);
                }
                Console.WriteLine($"Day {days}: {initialFish.Count}");
            }
            Console.WriteLine($"Total Fish {initialFish.Count}");
        }
    }

}
