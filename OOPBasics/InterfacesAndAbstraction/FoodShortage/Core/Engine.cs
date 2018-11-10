using FoodShortage.Contracts;
using FoodShortage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodShortage.Core
{
    public class Engine
    {
        private List<IBuyer> buyers;
        private List<string> fake;

        public Engine()
        {
            this.buyers = new List<IBuyer>();
            this.fake = new List<string>();
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string[] tokens = input.Split();
                string name = tokens[0];

                if (tokens.Length == 3)
                {
                    //rebel
                    int age = int.Parse(tokens[1]);
                    string group = tokens[2];

                    if (!fake.Contains(name))
                    {
                        IBuyer rebel = new Rebel(name, age, group, 0);

                        fake.Add(name);
                        buyers.Add(rebel);
                        //rebel.BuyFood();
                    }

                }
                else if (tokens.Length == 4)
                {
                    //citizen
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    string birthdate = tokens[3];

                    if (!fake.Contains(name))
                    {
                        IBuyer citizen = new Citizen(name, age, id, birthdate, 0);

                        fake.Add(name);
                        buyers.Add(citizen);
                        //citizen.BuyFood();
                    }
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                var buyer = buyers.FirstOrDefault(b => b.Name == command);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(buyers.Sum(b => b.Food));
        }
    }
}
