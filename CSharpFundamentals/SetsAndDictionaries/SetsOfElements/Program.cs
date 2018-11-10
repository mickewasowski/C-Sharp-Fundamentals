using System;
using System.Linq;
using System.Collections.Generic;

namespace SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();

            int[] lenghts = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int n = lenghts[0];
            int m = lenghts[1];

            for (int i = 0; i < n; i++)
            {
                int nums = int.Parse(Console.ReadLine());
                first.Add(nums);
            }
            for (int i = 0; i < m; i++)
            {
                int nums = int.Parse(Console.ReadLine());
                second.Add(nums);
            }

            var intersectedNums = first.Intersect(second);

            Console.WriteLine(string.Join(" ",intersectedNums));

            
        }
    }
}
