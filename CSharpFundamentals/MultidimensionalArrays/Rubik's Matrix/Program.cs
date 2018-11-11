using System;
using System.Linq;

namespace _051
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            int[][] rubikMatrix = new int[rows][];

            GetMatrix(rubikMatrix, rows, cols);

            int numCommands = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numCommands; i++)
            {
                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                int rowOrCol = int.Parse(commands[0]);
                string command = commands[1];
                int moves = int.Parse(commands[2]);

                if (command == "up")
                {
                    MoveUp(rubikMatrix, rowOrCol, moves % rubikMatrix.Length);
                }
                else if (command == "down")
                {
                    MoveDown(rubikMatrix, rowOrCol, moves % rubikMatrix.Length);
                }
                else if (command == "left")
                {
                    MoveLeft(rubikMatrix, rowOrCol, moves % rubikMatrix[0].Length);
                }
                else if (command == "right")
                {
                    MoveRight(rubikMatrix, rowOrCol, moves % rubikMatrix[0].Length);
                }
            }
            int counter = 1;
            for (int row = 0; row < rows; row++)
            {               
                for (int col = 0; col < cols; col++)
                {
                    if (rubikMatrix[row][col] == counter)
                    {
                        Console.WriteLine("No swap required");
                        counter++;
                    }
                    else
                    {
                        Rearange(rubikMatrix, rows, cols, counter);
                        counter++;
                    }
                }
            }
        }

        private static void Rearange(int[][] rubikMatrix, int rows, int cols, int counter)
        {
            for (int targetRow = 0; targetRow < rubikMatrix.Length; targetRow++)
            {
                for (int targetCol = 0; targetCol< rubikMatrix[targetRow].Length ;targetCol ++)
                {
                    if (rubikMatrix[targetRow][targetCol] == counter)
                    {
                        rubikMatrix[targetRow][targetCol] = rubikMatrix[rows][cols]; // така ги разменяме
                        rubikMatrix[rows][cols] = counter; 
                        Console.WriteLine($"Swap ({rows}, {cols}) with ({targetRow}, {targetCol})");//първо откъде тръгваме и после къде го намираме
                        return;
                    }
                }
            }
        }

        private static void MoveRight(int[][] rubikMatrix, int rowOrCol, int moves)
        {
            int lastElement = rubikMatrix[rowOrCol][rubikMatrix[rowOrCol].Length - 1]; 
            for (int i = 0; i < moves; i++)
            {
                for (int col = rubikMatrix[rowOrCol].Length - 1; col > 0; col--)
                {
                    rubikMatrix[rowOrCol][col] = rubikMatrix[rowOrCol][col - 1];
                }
                rubikMatrix[rowOrCol][0] = lastElement;
            }
        }

        private static void MoveLeft(int[][] rubikMatrix, int rowOrCol, int moves)
        {
            int firstElement = rubikMatrix[rowOrCol][0];
            for (int i = 0; i < moves; i++)
            {
                for (int col = 0; col < rubikMatrix[rowOrCol].Length - 1; col++)
                {
                    rubikMatrix[rowOrCol][col] = rubikMatrix[rowOrCol][col + 1];
                }
                rubikMatrix[rowOrCol][rubikMatrix[rowOrCol].Length - 1] = firstElement;
            }
        }

        private static void MoveDown(int[][] rubikMatrix, int rowOrCol, int moves)
        {
            int lastElement = rubikMatrix[rubikMatrix.Length - 1][rowOrCol]; 
            for (int i = 0; i < moves; i++)
            {
                for (int row = rubikMatrix.Length - 1; row > 0; row--) // row > 0 за да няма index out of range
                {
                    rubikMatrix[row][rowOrCol] = rubikMatrix[row - 1][rowOrCol];
                }
                rubikMatrix[0][rowOrCol] = lastElement;
            }
        }

        private static void MoveUp(int[][] rubikMatrix, int rowOrCol, int moves)
        {
            int firstElement = rubikMatrix[0][rowOrCol];

            for (int i = 0; i < moves; i++)
            {
                for (int row = 0; row < rubikMatrix.Length - 1; row++)
                {
                    rubikMatrix[row][rowOrCol] = rubikMatrix[row + 1][rowOrCol];
                }
                rubikMatrix[rubikMatrix.Length - 1][rowOrCol] = firstElement;
            }
        }
        private static void GetMatrix(int[][] rubikMatrix, int rows, int cols)
        {
            int values = 1;
            for (int row = 0; row < rows; row++)
            {
                rubikMatrix[row] = new int[cols];
                for (int col = 0; col < cols; col++)
                {
                    rubikMatrix[row][col] = values;
                    values++;
                }
            }
        }
    }
}
