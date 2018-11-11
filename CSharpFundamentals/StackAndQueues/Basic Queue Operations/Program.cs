using System;
using System.Collections.Generic;
using System.Linq;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] first = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            int[] second = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> stack = new Queue<int>();

            for (int i = 0; i < first[0]; i++)
            {
                stack.Enqueue(second[i]);
            }

            for (int i = first[1] - 1; i >= 0; i--)
            {
                stack.Dequeue();
            }

            if (stack.Count != 0)
            {
                if (stack.Contains(first[2]))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(stack.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
