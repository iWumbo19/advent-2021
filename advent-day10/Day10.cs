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
                            TotalIllegalValue += CharValues[symbol];
                            Console.WriteLine($"Expected {tracker.Peek()}: Found {symbol}: line {lineCounter}");
                            break;
                        }
                    }
                    lineCounter++;
                }
                IncompleteLines.Add(line);
            }


            
            Console.WriteLine($"Total Illegal Value: {TotalIllegalValue}");

        }
    }
}
