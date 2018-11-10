using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>(); 

            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();


            string command = Console.ReadLine();

            while (command != "Output")
            {
                string[] tokens = command.Split();
                var departament = tokens[0];
                var firstName = tokens[1];
                var secondName = tokens[2];
                var patient = tokens[3];
                var fullName = firstName + secondName;

                if (!doctors.ContainsKey(fullName)) 
                {
                    doctors[fullName] = new List<string>(); 
                }
                if (!departments.ContainsKey(departament))
                {
                    departments[departament] = new List<List<string>>();

                    for (int rooms = 0; rooms < 20; rooms++)
                    {
                        departments[departament].Add(new List<string>());
                    }
                }

                bool availableBed = departments[departament].SelectMany(x => x).Count() < 60;

                if (availableBed)
                {
                    int room = 0;

                    doctors[fullName].Add(patient); 

                    for (int st = 0; st < departments[departament].Count; st++)
                    {
                        if (departments[departament][st].Count < 3)
                        {
                            room = st;
                            break;
                        }
                    }
                    departments[departament][room].Add(patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] arguments = command.Split();

                if (arguments.Length == 1)
                {
                    string department = arguments[0];
                    Console.WriteLine(string.Join("\n", departments[department].Where(x => x.Count > 0).SelectMany(x => x)));
                }
                else if (arguments.Length == 2 && int.TryParse(arguments[1], out int room))
                {
                    string department = arguments[0];                
                    Console.WriteLine(string.Join("\n", departments[department][room - 1].OrderBy(x => x)));
                }
                else
                {
                    string doctor = arguments[0];                    
                    Console.WriteLine(string.Join("\n", doctors[doctor + arguments[1]].OrderBy(x => x))); 
                }
                command = Console.ReadLine();
            }
        }
    }
}
