using System;
using System.Linq;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int row = input[0];
            int col = input[1];

            int[,] matrix = new int[row, col];

            FillMatrix(row,col,matrix);
            MaxSumAndMatrix(row, col, matrix);
        }

        private static void MaxSumAndMatrix(int row, int col, int[,] matrix)
        {
            int currMax = 0;
            int max = 0;

            int targetRow = 0;
            int targetCol = 0;

            for (int i = 0; i < row - 2; i++)
            {
                for (int j = 0; j < col - 2; j++)
                {
                    currMax = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2]
                              + matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2]
                              + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];
                    if (currMax > max)
                    {
                        max = currMax;
                        targetRow = i;
                        targetCol = j;
                    }
                }
            }

            Console.WriteLine($"Sum = {max}");

            for (int i = targetRow; i <= targetRow + 2; i++)
            {
                for (int j = targetCol; j <= targetCol + 2; j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }
                Console.WriteLine();
            }
            
        }

        private static void FillMatrix(int row, int col,int[,] matrix)
        {            

            for (int i = 0; i < row; i++)
            {
                int[] rowsAndCols = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = rowsAndCols[j];
                }
            }
        }
    }
}
