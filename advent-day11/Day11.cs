using System;
using System.Collections.Generic;
using System.Linq;

namespace advent_day11
{
    class Day11
    {
        public static int _flashes = 0;
        static void Main(string[] args)
        {
            //Set up data structure
            List<List<int>> input = new List<List<int>>();
            foreach (string line in System.IO.File.ReadLines("day11-input"))
            {
                List<int> curLine = new List<int>();
                foreach (char digit in line)
                {
                    //Convert from Ascii
                    int num = digit - '0';
                    curLine.Add(num);
                }
                input.Add(curLine);
            }


            //Create array based on file params
            int[][] grid = input.Select(l => l.ToArray()).ToArray();


            //Main Loop//
            //For Every Day...
            for (int step = 0; step < 100; step++)
            {
                //Increases Octos
                grid = IncreaseAll(grid);

                //Initializes queue for cords to check
                Queue<Tuple<int, int>> CordToCheck = FindInitialFlashes(grid);

                //Keeps Track of nodes that have flashed
                List<Tuple<int, int>> Flashed = new List<Tuple<int, int>>();

                //Keeps Checking Neighbors that need to flash till there are none
                while (CordToCheck.Count > 0)
                {
                    Tuple<int, int> curCord = CordToCheck.Dequeue();
                    Flashed.Add(curCord);
                    _flashes++;
                    grid = IncreaseSurrounding(grid, curCord.Item1, curCord.Item2);
                    grid[curCord.Item1][curCord.Item2] = 0;
                    foreach (Tuple<int,int> item in GatherFlashingNeighbors(grid,curCord.Item1,curCord.Item2))
                    {
                        CordToCheck.Enqueue(item);
                    }

                }

                //Sets All Octo that Flashed this step to 0;
                foreach (Tuple<int,int> item in Flashed)
                {
                    grid[item.Item1][item.Item2] = 0;
                }
            }

            Console.WriteLine(_flashes);

        }

        //Increases all nodes by 1. Used at start of step
        public static int[][] IncreaseAll(int[][] grid)
        {
            int[][] output = grid;
            for (int row = 0; row < 10; row++)
            {
                for (int column = 0; column < 10; column++)
                {
                    output[row][column] += 1;
                }
            }
            return output;
        }


        //Increases nodes surrounding passed in node by 1
        public static int[][] IncreaseSurrounding(int[][] grid, int row, int column)
        {
            try { grid[row - 1][column] += 1; } catch { } //UP
            try { grid[row + 1][column] += 1; } catch { } //DOWN
            try { grid[row][column - 1] += 1; } catch { } //LEFT
            try { grid[row][column + 1] += 1; } catch { } //RIGHT

            try { grid[row + 1][column + 1] += 1; } catch { } //DOWN RIGHT
            try { grid[row + 1][column - 1] += 1; } catch { }  //DOWN LEFT
            try { grid[row - 1][column + 1] += 1; } catch { }  //UP RIGHT
            try { grid[row - 1][column - 1] += 1; } catch { }  //UP LEFT

            return grid;
        }


        //Searches passed in grid for nodes > 9
        public static Queue<Tuple<int,int>> FindInitialFlashes(int[][] grid)
        {
            Queue<Tuple<int, int>> output = new Queue<Tuple<int, int>>();
            for (int row = 0; row < 10; row++)
            {
                for (int column = 0; column < 10; column++)
                {
                    if (grid[row][column] > 9)
                    {
                        output.Enqueue(new Tuple<int, int>(row, column));
                    }
                }
            }
            return output;
        }


        //Checks if surrounding nodes are > 9
        public static List<Tuple<int,int>> GatherFlashingNeighbors(int[][] grid, int row, int column)
        {
            List<Tuple<int, int>> output = new List<Tuple<int, int>>();
            try { if (grid[row + 1][column] > 9) { output.Add(new Tuple<int, int>(row + 1, column)); } } catch { } //DOWN
            try { if (grid[row - 1][column] > 9) { output.Add(new Tuple<int, int>(row - 1, column)); } } catch { } //UP
            try { if (grid[row][column + 1] > 9) { output.Add(new Tuple<int, int>(row, column + 1)); } } catch { } //RIGHT
            try { if (grid[row][column - 1] > 9) { output.Add(new Tuple<int, int>(row, column - 1)); } } catch { } //LEFT

            try { if (grid[row + 1][column - 1] > 9) { output.Add(new Tuple<int, int>(row + 1, column - 1)); } } catch { }
            try { if (grid[row + 1][column + 1] > 9) { output.Add(new Tuple<int, int>(row + 1, column + 1)); } } catch { }
            try { if (grid[row - 1][column - 1] > 9) { output.Add(new Tuple<int, int>(row - 1, column - 1)); } } catch { }
            try { if (grid[row - 1][column + 1] > 9) { output.Add(new Tuple<int, int>(row - 1, column + 1)); } } catch { }

            return output;
        }
    }
}
