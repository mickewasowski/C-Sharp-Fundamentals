using System;
using System.Linq;
using System.Collections.Generic;

namespace PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Func<List<string>,int, List<string>> updatedNames = UpdateNames;

            names = updatedNames(names, n);

            foreach (var person in names)
            {
                Console.WriteLine(person);
            }
        }

        private static List<string> UpdateNames(List<string> names, int n)
        {
            for (int i = names.Count - 1; i >= 0; i--)
            {
                if (names[i].Length > n)
                {
                    names.RemoveAt(i);
                }
            }
            return names;
        }
    }
}
