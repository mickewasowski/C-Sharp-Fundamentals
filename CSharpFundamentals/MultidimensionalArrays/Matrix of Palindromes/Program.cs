using System;
using System.Linq;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int row = input[0];
            int col = input[1];

            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            string[,] matrix = new string[row,col];

            GetMatrix(matrix,row,col,alphabet);
            PrintMatrix(matrix,row,col);
        }

        private static void PrintMatrix(string[,] matrix, int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void GetMatrix(string[,] matrix, int row, int col, char[] alphabet)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = string.Concat(alphabet[i], alphabet[i + j], alphabet[i]);
                }
            }
        }
    }
}
