using System;

namespace advent_day2
{
    class Day2
    {
        static void Main(string[] args)
        {
            int horz = 0;
            int depth = 0;
            int aim = 0;
            foreach (string line in System.IO.File.ReadLines(@"day2-input.txt"))
            {
                
                string[] instructions = line.Split(' ');
                switch (instructions[0])
                {
                    case "forward":
                        horz += int.Parse(instructions[1]);
                        depth += aim * int.Parse(instructions[1]);
                        break;
                    case "down":
                        aim += int.Parse(instructions[1]);
                        break;
                    case "up":
                        aim -= int.Parse(instructions[1]);
                        break;
                    default:
                        break;
                } 
            }
            Console.WriteLine(horz * depth);
        }
    }
}
