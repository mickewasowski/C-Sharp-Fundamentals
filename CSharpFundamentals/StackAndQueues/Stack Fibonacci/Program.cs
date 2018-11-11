using System;
using System.Collections.Generic;

namespace _08
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            Stack<long> stack = new Stack<long>();

            stack.Push(0);
            stack.Push(1);

            for (long i = 0; i < n - 1; i++)
            {
                long first = stack.Pop();
                long second = stack.Peek();

                stack.Push(first);
                stack.Push(first + second);
            }
            Console.WriteLine(stack.Peek());
        }
    }
}
