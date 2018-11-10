using System;
using System.Linq;
using System.Collections.Generic;

namespace CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Func<List<int>, List<int>> ordered = GetOrdered;

            numbers = ordered(numbers);
            Console.WriteLine(string.Join(" ",numbers));
        }

        private static List<int> GetOrdered(List<int> numbers)
        {
            List<int> evens = new List<int>();
            List<int> odds = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    evens.Add(numbers[i]);
                }
                else
                {
                    odds.Add(numbers[i]);
                }
            }
            evens.Sort();
            odds.Sort();
            numbers.Clear();

            for (int i = 0; i < evens.Count; i++)
            {
                numbers.Add(evens[i]);
            }
            for (int i = 0; i < odds.Count; i++)
            {
                numbers.Add(odds[i]);
            }
            return numbers;
        }
    }
}
