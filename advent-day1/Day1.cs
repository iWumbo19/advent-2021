using System;

namespace advent_day2
{
    class Day2
    {
        static void Main(string[] args)
        {
            int increases = 0;
            int lastSum = 0;
            int[] altitudes = new int[2000];




            int lineCount = 0;
            foreach (string line in System.IO.File.ReadLines(@"day1-input.txt"))
            {
                altitudes[lineCount] = int.Parse(line);
                lineCount++;
            }



            for (int i = 0; i < 1998; i++)
            {
                int a = altitudes[i];
                int b = altitudes[i + 1];
                int c = altitudes[i + 2];
                int sum = a + b + c;
                if (lastSum != 0)
                {
                    if (sum > lastSum)
                    {
                        increases++;
                        lastSum = sum;
                    }
                    else { lastSum = sum; }
                }
                else { lastSum = sum; }
            }

            Console.WriteLine(increases);
            Console.ReadLine();

        }
    }
}
