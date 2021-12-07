using System;
using System.Collections.Generic;

namespace advent_day5
{
    class Day5
    {
        static void Main(string[] args)
        {
            Tunnel.IniArray();
            List<Vent> vents = new List<Vent>();
            foreach (string line in System.IO.File.ReadLines(@"day5-input"))
            {
                string[] cordinates = line.Split(' ');
                string startsFull = cordinates[0];
                string endsFull = cordinates[2];
                string[] starsSplit = startsFull.Split(',');
                string[] endsSplit = endsFull.Split(',');
                
                if (int.Parse(starsSplit[0]) == int.Parse(endsSplit[0]) ^
                    int.Parse(starsSplit[1]) == int.Parse(endsSplit[1]))
                {
                    vents.Add(new Vent(
                        int.Parse(starsSplit[0]), 
                        int.Parse(endsSplit[0]), 
                        int.Parse(starsSplit[1]), 
                        int.Parse(endsSplit[1])));
                }
            }
            Console.WriteLine(vents.Count);
            //Tunnel.PrintGrid();
            Console.WriteLine(Tunnel.CountTwos());


        }
    }

    public class Vent
    {
        int X1;
        int X2;
        int Y1;
        int Y2;

        public Vent(string[] cordinates)
        {
            string startsFull = cordinates[0];
            string endsFull = cordinates[2];
            string[] starsSplit = startsFull.Split(',');
            string[] endsSplit = endsFull.Split(',');

            X1 = int.Parse(starsSplit[0]);
            X2 = int.Parse(endsSplit[0]);
            Y1 = int.Parse(starsSplit[1]);
            Y2 = int.Parse(endsSplit[1]);
            //Console.WriteLine($"Line Created from {x1},{y1} to {x2},{y2}");
            Tunnel.DrawLine(X1, X2, Y1, Y2);
        }

        public Vent(int x1, int x2, int y1, int y2)
        {
            X1 = x1;
            X2 = x2;
            Y1 = y1;
            Y2 = y2;
            //Console.WriteLine($"Line Created from {x1},{y1} to {x2},{y2}");
            Tunnel.DrawLine(X1, X2, Y1, Y2);

        }

    }

    public static class Tunnel
    {
        private static int[,] Grid = new int[1000, 1000];

        public static void IniArray()
        {
            for (int row = 0; row < 1000; row++)
            {
                for (int column = 0; column < 1000; column++)
                {
                    Grid[row, column] = 0;
                }
            }
        }

        public static void DrawLine(int x1, int x2, int y1, int y2)
        {
            if (x1 == x2)
            {
                Console.WriteLine("Drawing Vertical Line");
                if (y1 < y2)
                {
                    for (int i = y1; i <= y2; i++)
                    {
                        Grid[x1, i] += 1;
                    }
                }
                else
                {
                    for (int i = y1; i >= y2; i--)
                    {
                        Grid[x1, i] += 1;
                    }
                }

            }
            else if (y1 == y2)
            {
                Console.WriteLine("Drawing Horizontal Line");

                if (x1 < x2)
                {
                    for (int i = x1; i <= x2; i++) 
                    {
                        Grid[i, y1] += 1;
                    }
                }
                else
                {
                    for (int i = x1; i >= x2; i--)
                    {
                        Grid[i, y1] += 1;
                    }
                }

            }
            else { Console.WriteLine("Well That's Wrong..."); }
        }

        public static void PrintGrid()
        {
            foreach (var item in Grid)
            {
                Console.WriteLine(item);
            }
        }

        public static int CountTwos()
        {
            int output = 0;
            for (int row = 0; row < 1000; row++)
            {
                for (int column = 0; column < 1000; column++)
                {
                    if (Grid[row,column] >= 2)
                    {
                        output += 1;
                    }
                }
            }
            return output;
        }
    }
}
