using BirthdayCelebrations.Contracts;
using BirthdayCelebrations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BirthdayCelebrations.Core
{
    public class Engine
    {
        private List<IIdentifiable> creatures;
        private List<IBirthable> birthdates;

        public Engine()
        {
            this.creatures = new List<IIdentifiable>();
            this.birthdates = new List<IBirthable>();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split();

                string type = tokens[0];

                if (type == "Robot")
                {
                    string model = tokens[1];
                    string id = tokens[2];

                    IIdentifiable robot = new Robot(model, id);
                    this.creatures.Add(robot);
                }
                else if(type == "Citizen")
                {
                    string name = tokens[1];
                    int age = int.Parse(tokens[2]);
                    string id = tokens[3];
                    string birthdate = tokens[4];

                    IBirthable ciizen = new Citizen(name, age, id,birthdate);
                    this.birthdates.Add(ciizen);
                }
                else if (type == "Pet")
                {
                    string name = tokens[1];
                    string birthdate = tokens[2];

                    IBirthable pet = new Pet(name, birthdate);
                    this.birthdates.Add(pet);
                }

                input = Console.ReadLine();
            }

            string year = Console.ReadLine();

            foreach (var item in birthdates.Where(x => x.BirthDate.EndsWith(year)))
            {
                Console.WriteLine(item.BirthDate);
            }
        }
    }
}
