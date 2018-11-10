using System;
using System.Linq;
using System.Collections.Generic;

namespace ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            List<string> editedGuests = new List<string>();

            List<string> filters = new List<string>();
            
            string input = Console.ReadLine();

            Action<List<string>> print = names => Console.WriteLine(string.Join(" ",names));

            while (input != "Print")
            {
                string[] arguments = input.Split(';').ToArray();
                string filter = arguments[0];
                string predicateName = arguments[1];
                string value = arguments[2];

                if (filter == "Add filter")
                {
                    filters.Add(predicateName + " " + value);
                }
                else if (filter == "Remove filter")
                {
                    filters.Remove(predicateName + " " + value);
                }
              
            input = Console.ReadLine();
            }
            foreach (var f in filters)
            {
                string[] commands = f.Split(' ');
                string command = commands[0];

                switch (command)
                {
                    case "Starts":
                        var starts = guests.Where(p => p.StartsWith(commands[2]));

                        foreach (var person in starts)
                        {
                            editedGuests.Add(person);
                        }
                        guests = guests.Except(editedGuests).ToList();

                        break;
                    case "Ends":
                        var ends = guests.Where(p => p.EndsWith(commands[2]));

                        foreach (var person in ends)
                        {
                            editedGuests.Add(person);
                        }
                        guests = guests.Except(editedGuests).ToList();

                        break;
                    case "Length":
                        var length = guests.Where(p => p.Length == int.Parse(commands[1]));

                        foreach (var person in length)
                        {
                            editedGuests.Add(person);
                        }
                        guests = guests.Except(editedGuests).ToList();

                        break;
                    case "Contains":
                        var contains = guests.Where(p => p.Contains(commands[1]));

                        foreach (var person in contains)
                        {
                            editedGuests.Add(person);
                        }
                        guests = guests.Except(editedGuests).ToList();

                        break;
                    default:
                        break;
                }
            }

            print(guests);
        } 
    }
}
