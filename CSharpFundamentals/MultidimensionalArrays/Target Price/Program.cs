using System;
using System.Collections.Generic;
using System.Linq;

namespace _061
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            string snake = Console.ReadLine();

            char[][] matrix = new char[rows][];

            GetMatrix(matrix, rows, cols,snake);

            int[] shotParams = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Shoot(matrix,shotParams);

            Collapse(matrix);

            PrintMatrix(matrix);

        }

        private static void Collapse(char[][] matrix)
        {
            Queue<char> elements = new Queue<char>(matrix.Length);

            for (int col = 0; col < matrix[0].Length; col++)
            {
                int counter = 0;

                for (int row = 0; row < matrix.Length; row++)
                {
                    if (matrix[row][col] != ' ')
                    {
                        elements.Enqueue(matrix[row][col]);
                    }
                    else
                    {
                        counter++;
                    }
                }

                for (int row = 0; row < counter; row++)
                {
                    matrix[row][col] = ' ';
                }
                for (int row = counter; row < matrix.Length; row++)
                {
                    matrix[row][col] = elements.Dequeue();
                }
            }
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static void Shoot(char[][] matrix, int[] shotParams)
        {
            int impactRow = shotParams[0];
            int impactCol = shotParams[1];
            int radius = shotParams[2];

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    bool isInside = Math.Pow((impactRow - row), 2) + Math.Pow((impactCol - col), 2) <= Math.Pow(radius, 2);

                    if (isInside)
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }
        }

        private static void GetMatrix(char[][] matrix, int rows, int cols, string snake)
        {
            int counter = 0;
            bool isLeft = true;

            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                matrix[row] = new char[cols];

                if (isLeft)
                {
                    for (int col = matrix[row].Length - 1; col >= 0; col--)
                    {
                        if (counter > snake.Length - 1)
                        {
                            counter = 0;
                        }
                        matrix[row][col] = snake[counter++];
                    }
                    isLeft = false;
                }
                else
                {           
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (counter > snake.Length - 1)
                        {
                            counter = 0;
                        }
                        matrix[row][col] = snake[counter++];
                    }
                    isLeft = true;
                }            
            }
        }
    }
}
