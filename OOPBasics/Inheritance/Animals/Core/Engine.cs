using Animals.Factories;
using Animals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals.Core
{
    public class Engine
    {
        private AnimalFactory animalFactory;
        private List<Animal> animals;

        public Engine()
        {
            this.animalFactory = new AnimalFactory();
            this.animals = new List<Animal>();
        }
        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "Beast!")
            {
                try
                {
                    string animalType = input;
                    string[] animalTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                    string name = animalTokens[0];
                    int age = int.Parse(animalTokens[1]);
                    string gender = animalTokens[2];

                    Animal animal = animalFactory.CreateAnimal(animalType, name, age, gender);
                    animals.Add(animal);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                input = Console.ReadLine();
            }
            Print();
        }

        private void Print()
        {
            foreach (var item in animals)
            {
                Console.WriteLine(item.GetType().Name);
                Console.WriteLine(item);
                item.ProduceSound();
            }
        }
    }
}
