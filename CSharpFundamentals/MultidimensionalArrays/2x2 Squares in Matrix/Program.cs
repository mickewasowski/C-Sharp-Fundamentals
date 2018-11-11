using System;
using System.Collections.Generic;
using System.Linq;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int row = input[0];
            int col = input[1];

            string[,] matrix = new string[row, col];

            FillMatrix(matrix,row,col);

            Console.WriteLine(GetSquareNums(matrix));
            
            
        }

        private static int GetSquareNums(string[,] matrix)
        {
            int count = 0;
           
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    bool areEqual = matrix[i, j] == matrix[i, j + 1] && matrix[i, j] == matrix[i + 1, j] && matrix[i, j] == matrix[i + 1, j + 1];

                    if (areEqual)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private static void FillMatrix(string[,] matrix, int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                string[] chars = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = chars[j];
                }
            }
        }
    }
}
