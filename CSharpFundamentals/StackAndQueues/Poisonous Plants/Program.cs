using System;
using System.Collections.Generic;
using System.Linq;

namespace _10
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> pesticides = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            List<int> indexes = new List<int>();
            int days = 0;

            while (true)
            {
                for (int i = 0; i < pesticides.Count - 1; i++)
                {
                    if (pesticides[i] < pesticides[i + 1])
                    {
                        indexes.Add(i + 1);
                    }
                }
                if (indexes.Count == 0)
                {
                    break;
                }
                for (int i = indexes.Count - 1; i >= 0; i--)
                {
                    pesticides.RemoveAt(indexes[i]);
                    indexes.RemoveAt(i);
                }
                days++;
                              
            }
            Console.WriteLine(days);
        }
    }
}
