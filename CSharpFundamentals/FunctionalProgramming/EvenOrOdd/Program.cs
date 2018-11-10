using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenOrOdd
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string command = Console.ReadLine();

            Func<int[], string, int[]> value = GetEvenOrOdd;

            Console.WriteLine(string.Join(" ", value(range,command)));

        }

        private static int[] GetEvenOrOdd(int[] range, string command)
        {
            int first = range[0];
            int last = range[1];
            List<int> list = new List<int>();
            switch (command)
            {
                case "even":
                    for (int i = first; i <= last; i++)
                    {
                        list.Add(i);
                    }
                    int[] even = list.Where(n => n % 2 == 0).ToArray();
                    return even;
                case "odd":
                    for (int i = first; i <= last; i++)
                    {
                        list.Add(i);
                    }
                    int[] odd = list.Where(n => n % 2 != 0).ToArray();
                    return odd;
                default:
                    return null;
            }            
        }
    }
}
