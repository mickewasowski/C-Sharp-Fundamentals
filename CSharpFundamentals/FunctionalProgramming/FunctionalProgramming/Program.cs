using System;
using System.Linq;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            Action<string> print = sir => Console.WriteLine($"Sir {sir}");

            foreach (var person in names)
            {
                print(person);
            }
        }
    }
}
