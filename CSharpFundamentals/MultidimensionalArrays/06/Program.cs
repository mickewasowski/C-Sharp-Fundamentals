using System;
using System.Linq;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            string snake = Console.ReadLine();
            char[] snakeArray = snake.ToCharArray();

            int[] shotParams = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int impactRow = shotParams[0];
            int impactCol = shotParams[1];
            int radius = shotParams[2];

            char[,] matrix = new char[rows,cols];

            GetMatrix(matrix, rows, cols,snakeArray);
        }

        private static void GetMatrix(char[,] matrix, int rows, int cols, char[] snakeArray)
        {
            int row = rows - 1;
            for (int i = rows - 1; i >= 0; i--)
            {             
                matrix[row,cols - 1] = snakeArray[0];
                int index = 0;         
                for (int j = cols - 2; j >= 0; j--)
                {
                    matrix[i,j] = snakeArray[snakeArray.Length - 2 - j];
                    index++;
                }
                matrix[i - 1, index] = snakeArray[snakeArray.Length - 1];
                row--;
            }
            Console.WriteLine();
        }
    }
}
