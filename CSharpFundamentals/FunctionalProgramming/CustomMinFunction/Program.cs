using System;
using System.Linq;

namespace CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Func<int[], int> minValue = GetMinValue;

            Console.WriteLine(minValue(numbers));
        }
        private static int GetMinValue(int[] numbers)
        {
            int min = numbers.Max();

            foreach (var num in numbers)
            {
                if (min > num)
                {
                    min = num;
                }
            }
            return min;
        }
    }
}
