using Animals.Exceptions;
using Animals.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Factories
{
    public class AnimalFactory
    {
        public Animal CreateAnimal(string animalType, string name, int age, string gender)
        {
            switch (animalType)
            {
                case "Cat":
                    return new Cat(name, age, gender);
                case "Dog":
                    return new Dog(name, age, gender);
                case "Frog":
                    return new Frog(name, age, gender);
                case "Kitten":
                    return new Kitten(name, age);
                case "Tomcat":
                    return new Tomcat(name, age);
                default:
                    throw new InvalidInput();
            }
        }
    }
}

