using System;
using System.Linq;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int row = dimensions[0];
            int col = dimensions[1];


            int[][] rubikMatrix = new int[row][];

            GetMatrix(rubikMatrix, col);

            int numCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numCommands; i++)
            {
                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int rowColIndex = int.Parse(commands[0]);
                string direction = commands[1];
                int moves = int.Parse(commands[2]);

                if (direction == "down")
                {
                    MoveDown(rubikMatrix, rowColIndex, moves % rubikMatrix.Length); // moves % rubikMAtrix.Length ни пази от гърмеж ако ни дадат въртене по голямо от нашите възможности за матрицата 
                }else if (direction == "left")
                {
                    MoveLeft(rubikMatrix, rowColIndex, moves % rubikMatrix[0].Length); //защото всички редове са с еднакви колони?
                }
                else if (direction == "right")
                {                
                    MoveRight(rubikMatrix, rowColIndex, moves % rubikMatrix[0].Length); //защото всички редове са с еднакви колони?
                }
                else if (direction == "up")
                {
                    MoveUp(rubikMatrix, rowColIndex, moves % rubikMatrix.Length);
                }
            }

            int counter = 1;

            for (int rows = 0; rows < rubikMatrix.Length; rows++)
            {
                for (int cols = 0; cols < rubikMatrix[rows].Length; cols++)
                {
                    if (rubikMatrix[rows][cols] == counter)
                    {
                        Console.WriteLine("No swap required");
                        counter++;
                    }
                    else
                    {
                        Rearange(rubikMatrix, rows, cols,counter);
                        counter++;
                    }
                }
            }
        }

        private static void Rearange(int[][] rubikMatrix, int rows, int cols,int counter)
        {
            for (int targetRow = 0; targetRow < rubikMatrix.Length; targetRow++)
            {
                for (int targetCol = 0; targetCol < rubikMatrix[targetRow].Length; targetCol++)
                {
                    if (rubikMatrix[targetRow][targetCol] == counter)
                    {
                        rubikMatrix[targetRow][targetCol] = rubikMatrix[rows][cols]; //тук идеята е да им разменим местата
                        rubikMatrix[rows][cols] = counter;
                        Console.WriteLine($"Swap ({rows}, {cols}) with ({targetRow}, {targetCol})"); //първо печатаме откъде тръгваме и после къде сме го намерили
                        return;
                    }
                }
            }
        }

        private static void MoveUp(int[][] rubikMatrix, int rowColIndex, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int firstElement = rubikMatrix[0][rowColIndex];

                for (int row = 0; row < rubikMatrix.Length - 1; row++)
                {
                    rubikMatrix[row][rowColIndex] = rubikMatrix[row + 1][rowColIndex];
                }
                rubikMatrix[rubikMatrix.Length - 1][rowColIndex] = firstElement;
            }
        }

        private static void MoveRight(int[][] rubikMatrix, int rowColIndex, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int lastElement = rubikMatrix[rowColIndex][rubikMatrix[rowColIndex].Length - 1];

                for (int col = rubikMatrix.Length - 1; col > 0; col--)
                {
                    rubikMatrix[rowColIndex][col] = rubikMatrix[rowColIndex][col - 1];
                }
                rubikMatrix[rowColIndex][0] = lastElement;
            }           
        }

        private static void MoveLeft(int[][] rubikMatrix, int rowColIndex, int moves) //rowColIndex => in this case row
        {
            for (int i = 0; i < moves; i++)
            {
                int firstElement = rubikMatrix[rowColIndex][0];

                for (int col = 0; col < rubikMatrix[rowColIndex].Length - 1; col++)
                {
                    rubikMatrix[rowColIndex][col] = rubikMatrix[rowColIndex][col + 1];
                }

                rubikMatrix[rowColIndex][rubikMatrix[rowColIndex].Length - 1] = firstElement;
            }
        }

        private static void MoveDown(int[][] rubikMatrix, int rowColIndex , int moves) //rowColIndex => col in this case
        {         
            for (int i = 0; i < moves; i++)
            {
                int lastElement = rubikMatrix[rubikMatrix.Length - 1][rowColIndex];

                for (int row = rubikMatrix.Length - 1; row > 0; row--) // въртим до нула за да няма index out of range exception
                {
                    rubikMatrix[row][rowColIndex] = rubikMatrix[row - 1][rowColIndex];
                }

                rubikMatrix[0][rowColIndex] = lastElement;
            }
        }

        //private static void PrintMatrix(int[][] rubikMatrix)
        //{
        //    for (int i = 0; i < rubikMatrix.Length; i++)
        //    {
        //        Console.WriteLine(String.Join(" ", rubikMatrix[i]));
        //    }
        //}

        private static void GetMatrix(int[][] rubikMatrix, int col)
        {
                int counter = 1;
            for (int rows = 0; rows < rubikMatrix.Length; rows++)
            {
                rubikMatrix[rows] = new int[col];
                for (int cols = 0; cols < rubikMatrix[rows].Length; cols++)
                {
                    rubikMatrix[rows][cols] = counter;
                    counter++;
                }
            }
        }
    }
}
