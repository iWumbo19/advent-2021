using System;
using System.Collections.Generic;

namespace advent_day3
{
    class Day3
    {
        static void Main(string[] args)
        {
            #region FIND POWER CONSUMPTION
            float[] gamma = new float[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            float[] epsilon = new float[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int lines = 0;

            foreach (string line in System.IO.File.ReadLines(@"day3-input.txt"))
            {
                int counter = 0;
                foreach(char digit in line)
                {                    
                    gamma[counter] += digit;
                    counter++;
                }
                lines++;
            }

            for (int i = 0; i < gamma.Length; i++)
            {
                if ((gamma[i] / lines) - 48 > .5)
                {
                    gamma[i] = 1;
                }
                else if ((gamma[i] / lines) - 48 < .5)
                {
                    gamma[i] = 0;
                }
                else { Console.WriteLine("FUCK YOU"); }
            }
            float[] mostCommon = gamma;

            for (int i = 0; i < gamma.Length; i++)
            {
                if (gamma[i] == 1)
                {
                    epsilon[i] = 0;
                }
                else { epsilon[i] = 1; }
            }

            //foreach (float item in gamma) { Console.Write($"{item} "); }
            //Console.WriteLine();
            //foreach (float item in epsilon) { Console.Write($"{item} "); }

            int exp = 1;
            int gamdecimal = 0;
            int epsidecimal = 0;
            for (int i = gamma.Length - 1; i >= 0; i--)
            {
                if (gamma[i] == 1){ gamdecimal += exp; }
                if (epsilon[i] == 1){ epsidecimal += exp; }
                exp = exp * 2;
            }
            Console.WriteLine($"Power Rating:{gamdecimal * epsidecimal}");
            #endregion


            #region FIND OXYGEN AND SCRUBBER RATING
            List<string> oxyList = new List<string>();
            List<string> co2List = new List<string>();


            foreach (string line in System.IO.File.ReadLines(@"day3-input.txt"))
            {
                oxyList.Add(line);
                co2List.Add(line);
            }
            Console.WriteLine(oxyList[0].Length);


            for (int i = 0; i < oxyList[0].Length; i++) { oxyList = Shake(oxyList, mostCommon[i], i, true); }
            for (int i = 0; i < co2List[0].Length; i++) { co2List = Shake(co2List, mostCommon[i], i, true); }
            Console.WriteLine($"{oxyList.Count}  {co2List.Count}");


            #endregion
        }

        public static List<string> Shake(List<string> curList, float popular, int index, bool most)
        {
            if (curList.Count == 1) { return curList; }
            List<string> output = new List<string>();

            foreach (string line in curList)
            {
                if (most == true)
                {
                    if (line[index] == popular) { output.Add(line); }
                }
                else
                {
                    if (line[index] != popular) { output.Add(line); }
                }
            }

            return output;
        }
    }
}
