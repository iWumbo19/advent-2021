using System;
using System.Collections;
using System.Collections.Generic;

namespace advent_day10
{
    class Day10
    {
        public static List<char> Openers = new List<char>() { '(', '[', '{', '<' };
        public static List<char> Closers = new List<char>() { ')', ']', '}', '>' };
        public static Dictionary<char, int> CharValues = new Dictionary<char, int>() { { ')', 3 }, { ']', 57 }, { '}', 1197 }, { '>', 25137 } };
        public static Dictionary<char,char> Counterpart = new Dictionary<char, char>() { { '(', ')' }, { '[', ']' }, { '{', '}' }, { '<', '>' } };
        public static List<string> IncompleteLines = new List<string>();
        public static List<int> LineErrorScores = new List<int>();

        public static List<char> IllegalChars = new List<char>();
        public static int TotalIllegalValue = 0;
        static void Main(string[] args)
        {
            int lineCounter = 1;
            foreach(string line in System.IO.File.ReadLines("day10-input"))
            {
                Stack<char> tracker = new Stack<char>();
                foreach (char symbol in line)
                {
                    if (Openers.Contains(symbol))
                    {
                        tracker.Push(symbol);
                    }
                    else
                    {
                        if (symbol == Counterpart[tracker.Peek()])
                        {
                            tracker.Pop();
                        }
                        else
                        {
                            break;
                        }
                    }
                    lineCounter++;
                }
                Console.WriteLine($"Adding Line {IncompleteLines.Count}");
                IncompleteLines.Add(line);
            }

            foreach (string line in IncompleteLines)
            {
                Stack<char> tracker = new Stack<char>();
                foreach (char symbol in line)
                {
                    if (Openers.Contains(symbol))
                    {
                        tracker.Push(symbol);
                    }
                    else
                    {
                        tracker.Pop();
                    }
                    lineCounter++;
                }

                Console.WriteLine($"Adding {tracker.Count} to Value");
                int stackSize = tracker.Count;
                TotalIllegalValue = 0;
                while (tracker.Count > 0)
                {
                    char adder = tracker.Pop();
                    if (adder == '(')
                    {
                        TotalIllegalValue += TotalIllegalValue * 5;
                        TotalIllegalValue += 1;
                    }
                    else if (adder == '[')
                    {
                        TotalIllegalValue += TotalIllegalValue * 5;
                        TotalIllegalValue += 2;
                    }
                    else if (adder == '{')
                    {
                        TotalIllegalValue += TotalIllegalValue * 5;
                        TotalIllegalValue += 3;
                    }
                    else if (adder == '<')
                    {
                        TotalIllegalValue += TotalIllegalValue * 5;
                        TotalIllegalValue += 4;
                    }
                }
                LineErrorScores.Add(TotalIllegalValue);
            }
            LineErrorScores.Sort();

            decimal middle = Math.Round((decimal)LineErrorScores.Count / 2);
            
            Console.WriteLine($"{LineErrorScores[(int)middle]}");

        }
    }
}
