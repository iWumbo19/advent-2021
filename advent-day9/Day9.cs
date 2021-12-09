using System;
using System.Collections.Generic;
using System.Linq;

namespace advent_day9
{
    class Day9
    {
        static void Main(string[] args)
        {
            if ((1==1 ^ 1==0))
            {
                Console.WriteLine("Works");
            }
            //Add all lines to List of List of ints  (Did you know chars as ints are the ascii value? I didn't)
            List<List<int>> mapLists = new List<List<int>>();
            foreach (string line in System.IO.File.ReadLines("day9-input")) 
            {
                List<int> curLine = new List<int>();
                foreach (char digit in line)
                {
                    int num = digit - '0';
                    curLine.Add(num);
                }
                mapLists.Add(curLine);
            }


            //Create array based on file params
            int[][] map = mapLists.Select(l => l.ToArray()).ToArray();


            //For every point in array. Check all neighbors
            List<int> lowPoints = new List<int>();
            for (int row = 0; row < mapLists.Count; row++)
            {
                for (int column = 0; column < mapLists[0].Count; column++)
                {
                    int point = map[row][column];
                    int upPoint;
                    int downPoint;
                    int leftPoint;
                    int rightPoint;
                    try { upPoint = map[row - 1][column]; } catch (Exception) { upPoint = -1; }
                    try { downPoint = map[row + 1][column]; } catch (Exception) { downPoint = -1; }
                    try { leftPoint = map[row][column - 1]; } catch (Exception) { leftPoint = -1; }
                    try { rightPoint = map[row][column + 1]; } catch (Exception) { rightPoint = -1; }

                    //If all neighbors are lower (or don't exist) add to lowpoint list
                    if ((point < upPoint ^ upPoint == -1) &&
                        (point < downPoint ^ downPoint == -1) &&
                        (point < leftPoint ^ leftPoint == -1) &&
                        (point < rightPoint ^ rightPoint == -1))
                    {
                        lowPoints.Add(point);
                    }
                }
            }

            //Gimmie that sweet data
            int counter = 0;
            foreach (int item in lowPoints)
            {
                counter += item + 1;
            }
            Console.WriteLine(counter);
        }
    }
}
