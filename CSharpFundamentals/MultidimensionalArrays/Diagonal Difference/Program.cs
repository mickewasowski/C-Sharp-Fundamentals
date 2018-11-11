using System;
using System.Linq;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            //square matrix 
            int size = int.Parse(Console.ReadLine());

            int[,] square = new int[size,size];

            GetSquareMatrix(size,square);

            int primary = 0;
            int secondary = 0;

            
            primary += GetPrimaryDiagonal(square, size);
       
            secondary = GetSecondaryDiagonal(square, size);
            
            PrintDifference(primary,secondary);
            
        }

        private static void PrintDifference(int primary, int secondary)
        {
            int difference = Math.Abs(primary - secondary);
            Console.WriteLine(difference);
        }

        private static int GetPrimaryDiagonal(int[,] square, int size)
        {
            int primary = 0;
            for (int j = 0; j < size; j++)
            {
                primary += square[j, j];
            }
            return primary;
            
        }
        private static int GetSecondaryDiagonal(int[,] square, int size)
        {
            int secondary = 0;
            for (int i = 0; i < size; i++)
            {
                secondary += square[i, size - 1 - i];
            }
            return secondary;
        }

        private static void GetSquareMatrix(int size, int[,] square)
        {
            for (int i = 0; i < size; i++)
            {
                int[] values = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < size; j++)
                {
                    square[i, j] = values[j];
                }
            }
        }
    }
}
