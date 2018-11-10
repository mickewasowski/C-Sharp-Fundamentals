using System;
using System.Linq;
using System.Collections.Generic;

namespace PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {            
            List<string> people = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList();

            string input = Console.ReadLine();

            Predicate<string> predicate;

            Action<List<string>> print = names => Console.WriteLine(string.Join(", ",names) + " are going to the party!");

            while (input != "Party!")
            {
                string[] arguments = input.Split();

                string command = arguments[0];
                string predicateName = arguments[1];
                string value = arguments[2];

                predicate = GetPredicate(predicateName, value);

                if (command == "Remove")
                {
                    people.RemoveAll(predicate);
                }
                else
                {
                    var newCollection = people.FindAll(predicate);

                    foreach (var guest in newCollection)
                    {
                        var currIndex = people.IndexOf(guest);

                        people.Insert(currIndex + 1, guest);
                    }
                }
                input = Console.ReadLine();
            }

            if (people.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                print(people);
            }
        }

        private static Predicate<string> GetPredicate(string predicateName, string value)
        {
            if (predicateName == "StartsWith")
            {
                return p => p.StartsWith(value);
            }
            else if (predicateName == "EndsWith")
            {
                return p => p.EndsWith(value);
            }
            else if (predicateName == "Length")
            {
                return p => p.Length == int.Parse(value);
            }
            else
            {
                return null;
            }

        }
    }
}
