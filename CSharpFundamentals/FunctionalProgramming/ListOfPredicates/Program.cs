using System;
using System.Linq;
using System.Collections.Generic;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Func<int, int[], List<int>> divisible = GetDivisible;

            var listOfDivided = divisible(n, dividers);

            Console.WriteLine(string.Join(" ",listOfDivided));
        }

        private static List<int> GetDivisible(int n, int[] dividers)
        {
            List<int> list = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                list.Add(i);
            }
            for (int i = 0; i < dividers.Length; i++)
            {
                list.RemoveAll(x => x % dividers[i] != 0);
            }
            return list;
        }
    }
}
