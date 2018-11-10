using BorderControl.Contracts;
using BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BorderControl.Core
{
    public class Engine
    {
        private List<IIdentifiable> creatures;

        public Engine()
        {
            this.creatures = new List<IIdentifiable>();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split();

                if (tokens.Length == 2)
                {
                    string model = tokens[0];
                    string id = tokens[1];

                    IIdentifiable robot = new Robot(model, id);
                    this.creatures.Add(robot);
                }
                else
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];

                    IIdentifiable ciizen = new Citizen(name, age, id);
                    this.creatures.Add(ciizen);
                }

                input = Console.ReadLine();
            }

            string fakeId = Console.ReadLine();

            foreach (var item in creatures.Where(x => x.Id.EndsWith(fakeId)))
            {
                Console.WriteLine(item.Id);
            }

            //this.creatures = this.creatures.Where(x => !x.Id.EndsWith(fakeId)).ToList(); if we're using ICollection
            this.creatures.RemoveAll(x => x.Id.EndsWith(fakeId));
        }
    }
}
