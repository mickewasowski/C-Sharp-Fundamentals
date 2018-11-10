using System;
using System.Linq;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            Action<string> print = name => Console.WriteLine(name);

            foreach (var person in names)
            {
                print(person);
            }
        }
    }
}
