using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace advent_day4
{
    class Day4
    {
        static void Main(string[] args)
        {
            //Reads teh first line of the file and writes it to a number array
            string firstLine = System.IO.File.ReadLines("day4-input.txt").First();
            string[] numbers = firstLine.Split(',');

            //Creates List of Boards and Lines List
            List<BingoBoard> Boards = new List<BingoBoard>();
            List<string> Lines = new List<string>();


            //Reads All Lines to List to be parsed thorugh
            foreach (string line in System.IO.File.ReadLines(@"day4-input.txt"))
            {
                if (line.Contains(','))
                {
                    Console.WriteLine("Ignored First Line");
                    continue;
                }
                Lines.Add(line);
            }


            //Build Boards
            for (int line = 0; line < Lines.Count; line += 6)
            {
                List<string> line1 = ToStringList(Lines[line + 1].Split(' '));
                List<string> line2 = ToStringList(Lines[line + 2].Split(' '));
                List<string> line3 = ToStringList(Lines[line + 3].Split(' '));
                List<string> line4 = ToStringList(Lines[line + 4].Split(' '));
                List<string> line5 = ToStringList(Lines[line + 5].Split(' '));
                List<List<string>> data = new List<List<string>>()
                {
                    {line1 },
                    {line2 },
                    {line3 },
                    {line4 },
                    {line5 }
                };
                //foreach (List<string> items in data)
                //{
                //    foreach (string item in items)
                //    {
                //        Console.Write(item);
                //    }
                //    Console.WriteLine();
                //}

                int[,] board = ToIntArray(data);
                //Console.WriteLine(String.Join(" ", board.Cast<int>()));
                //Console.WriteLine("\n\n");
                BingoBoard nuBoard = new BingoBoard(board);
                Boards.Add(nuBoard);
            }


            //Print Boards
            //foreach (BingoBoard board in Boards)
            //{
            //    board.PrintCard();
            //}


            //Start Calling Numbers
            int place = 1;
            for (int number = 0; number < numbers.Length; number++)
            {
                Console.WriteLine($"Calling Number: {numbers[number]}");
                for (int board = 0; board < Boards.Count; board++)
                {
                    Boards[board].CallNumber(int.Parse(numbers[number]));
                    if (!Boards[board].Solved && Boards[board].CheckBingo())
                    {
                        CalculateResult(Boards[board], int.Parse(numbers[number]), place);
                        place++;
                    }
                    else {  }
                }
            }
        }

        static public int[,] ToIntArray(List<List<string>> array)
        {
            int[,] output = new int[5, 5];
            int counter = 0;
            foreach (List<string> item in array)
            {
                for (int i = 0; i < array[0].Count; i++)
                {
                    output[counter, i] = int.Parse(array[counter][i]);
                }
                counter++;
            }           
            return output;
        }

        static public List<string> ToStringList(string[] array)
        {
            
            List<string> output = new List<string>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != "")
                {
                    output.Add(array[i]);
                }
            }
            return output;
        }

        static public void CalculateResult(BingoBoard board, int number, int place)
        {
            Console.WriteLine($"Card {place}: {board.AddUnmarked() * number}");
        }

    }

    public class BingoBoard
    {
        int[,] Board = new int[5,5];
        bool[,] Checked = new bool[5, 5];
        public bool Solved = false;
        public BingoBoard(int[,] board)
        {
            Board = board;

            //Initialize Bool Checked
            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    Checked[row, column] = false;
                }
            }
        }

        public void CallNumber(int number)
        {
            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    if (Board[row,column] == number) { Checked[row, column] = true; }
                }
            }
        }

        public bool CheckBingo()
        {
            //Check all Rows
            for (int row = 0; row < 5; row++)
            {
                if (Checked[row, 0] == true &&
                    Checked[row, 1] == true &&
                    Checked[row, 2] == true &&
                    Checked[row, 3] == true &&
                    Checked[row, 4] == true)
                {
                    Solved = true;
                    return true;
                }
            }

            //Check all Columns
            for (int column = 0; column < 5; column++)
            {
                if (Checked[0, column] == true &&
                    Checked[1, column] == true &&
                    Checked[2, column] == true &&
                    Checked[3, column] == true &&
                    Checked[4, column] == true)
                {
                    Solved = true;
                    return true;
                }
            }

            //Check Diag1            
            if (Checked[0, 0] == true &&
                Checked[1, 1] == true &&
                Checked[2, 2] == true &&
                Checked[3, 3] == true &&
                Checked[4, 4] == true)
            {
                Solved = true;
                return true;
            }
            
            
            //Check Diag2            
            if (Checked[0, 4] == true &&
                Checked[1, 3] == true &&
                Checked[2, 2] == true &&
                Checked[3, 1] == true &&
                Checked[4, 0] == true)
            {
                Solved = true;
                return true;
            }
            

            return false;
        }

        public void PrintCard()
        {
            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    Console.Write(Board[row, column]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public int AddUnmarked()
        {
            int output = 0;
            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    if (!Checked[row,column])
                    {
                        output += Board[row, column];
                    }
                }
            }
            return output;
        }
        
    }


}
