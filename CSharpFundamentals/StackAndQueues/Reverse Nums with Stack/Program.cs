using System;
using System.Collections.Generic;
using System.Linq;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < array.Length; i++)
            {
                stack.Push(array[i]);
            }

            while (stack.Count != 0)
            {
                Console.Write((stack.Pop() + " "));      
            }
            Console.WriteLine();
        }
    }
}
