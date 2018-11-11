using System;
using System.Collections.Generic;
using System.Linq;

namespace _07
{
    class Program
    {
        static int playerRow;
        static int playerCol;
        static char[][] jaggedArray;
        static bool isOutside;
        static bool isDead;

        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            jaggedArray = new char[rows][];

            GetJaggedArray(cols);

            

            string directions = Console.ReadLine();

            MovePlayer(directions);
        }

        private static void MovePlayer(string directions)
        {
            for (int i = 0; i < directions.Length; i++)
            {
                char currStep = directions[i];

                if (currStep == 'U')
                {
                    Move(-1, 0);
                }

                else if (currStep == 'D')
                {
                    Move(1, 0);
                }

                else if (currStep == 'L')
                {
                    Move(0, -1);
                }

                else if (currStep == 'R')
                {
                    Move(0, 1);
                }

                Spread();

                if (isDead)
                {
                    PrintJaggedArray();
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    break;
                }
                else if (isOutside)
                {
                    PrintJaggedArray();
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    break;
                }
            }
        }

        private static void Spread()
        {
            Queue<int[]> indexes = new Queue<int[]>();
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    if (jaggedArray[row][col] == 'B')
                    {
                        indexes.Enqueue(new int[] { row, col });
                    }
                }
            }

            while (indexes.Count > 0)
            {
                int[] currIndex = indexes.Dequeue();

                int targetRow = currIndex[0];
                int targetCol = currIndex[1];

                if (IsInside(targetRow - 1,targetCol))
                {
                    if (IsPlayer(targetRow - 1, targetCol))
                    {
                        isDead = true;
                    }
                    jaggedArray[targetRow - 1][targetCol] = 'B';
                }
                if (IsInside(targetRow + 1, targetCol))
                {
                    if (IsPlayer(targetRow + 1, targetCol))
                    {
                        isDead = true;
                    }
                    jaggedArray[targetRow + 1][targetCol] = 'B';
                }
                if (IsInside(targetRow , targetCol - 1))
                {
                    if (IsPlayer(targetRow , targetCol - 1))
                    {
                        isDead = true;
                    }
                    jaggedArray[targetRow ][targetCol - 1] = 'B';
                }
                if (IsInside(targetRow , targetCol + 1))
                {
                    if (IsPlayer(targetRow , targetCol + 1))
                    {
                        isDead = true;
                    }
                    jaggedArray[targetRow ][targetCol + 1] = 'B';
                }
            }
        }

        private static bool IsPlayer(int row, int col)
        {
            return jaggedArray[row][col] == 'P';
        }

        private static void Move(int row, int col)
        {
            int targetRow = playerRow + row;
            int targetCol = playerCol + col;

            if (!IsInside(targetRow,targetCol))
            {
                jaggedArray[playerRow][playerCol] = '.';
                isOutside = true;
            }else if (IsBunny(targetRow,targetCol))
            {
                jaggedArray[playerRow][playerCol] = '.';
                playerRow += row;
                playerCol += col;
                isDead = true;
            }
            else
            {
                jaggedArray[playerRow][playerCol] = '.';

                playerRow += row;
                playerCol += col;

                jaggedArray[playerRow][playerCol] = 'P';
            }
        }

        private static bool IsBunny(int targetRow, int targetCol)
        {
            return jaggedArray[targetRow][targetCol] == 'B';
        }

        private static bool IsInside(int targetRow, int targetCol)
        {
            return targetRow >= 0 && targetRow < jaggedArray.Length && targetCol >= 0 && targetCol < jaggedArray[targetRow].Length;
        }

        private static void PrintJaggedArray()
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                Console.WriteLine(String.Join("",jaggedArray[row]));
            }
        }

        private static void GetJaggedArray(int cols)
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = new char[cols];

                string input = Console.ReadLine();

                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    jaggedArray[row][col] = input[col];

                    if (jaggedArray[row][col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
        }
    }
}
