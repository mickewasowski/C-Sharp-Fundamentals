﻿using System;
using System.Linq;

namespace LegoBlocks
{
    class LegoBlocks
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] firstMatrix = new int[rows][];
            int[][] secondMatrix = new int[rows][];          

            int totalCells = 0;

            for (int row = 0; row < rows; row++)
            {
                firstMatrix[row] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                totalCells += firstMatrix[row].Length;
            }

            for (int row = 0; row < rows; row++)
            {
                secondMatrix[row] = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Reverse().Select(int.Parse).ToArray();
                totalCells += secondMatrix[row].Length;
            }

            int colLenght = firstMatrix[0].Length + secondMatrix[0].Length;

            bool isFit = true;

            for (int row = 0; row < firstMatrix.Length; row++)
            {
                if (firstMatrix[row].Length + secondMatrix[row].Length != colLenght)
                {
                    isFit = false;
                    break;
                }
            }
            if (isFit)
            {
                for (int row = 0; row < firstMatrix.Length; row++)
                {
                    Console.WriteLine($"[{string.Join(", ",firstMatrix[row])}, {string.Join(", ", secondMatrix[row])}]");
                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {totalCells}");
            }
        }
    }
}
