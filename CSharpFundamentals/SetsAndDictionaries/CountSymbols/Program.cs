using System;
using System.Linq;
using System.Collections.Generic;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

            string input = Console.ReadLine();

            foreach (var currChar in input)
            {
                if (!symbols.ContainsKey(currChar))
                {
                    symbols.Add(currChar, 0);
                }
                symbols[currChar] += 1;
            }

            foreach (var charr in symbols)
            {
                Console.WriteLine($"{charr.Key}: {charr.Value} time/s");
            }
        }
    }
}
