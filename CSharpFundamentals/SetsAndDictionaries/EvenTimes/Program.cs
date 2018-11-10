using System;
using System.Linq;
using System.Collections.Generic;

namespace EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            //var query = lst.GroupBy(x => x)
            //  .Where(g => g.Count() > 1)
            //  .Select(y => y.Key)
            //  .ToList();

            int n = int.Parse(Console.ReadLine());
            List<int> numbers = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int currNum = int.Parse(Console.ReadLine());
                numbers.Add(currNum);
            }

            var duplicate = numbers.GroupBy(x => x).Where(x => x.Count() % 2 == 0).Select(y => y.Key).ToList(); // x => x.Count() > 1

            foreach (var num in duplicate)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}
