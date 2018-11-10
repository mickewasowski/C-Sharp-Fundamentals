﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02_CarsSalesman
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            List<Engine> engines = new List<Engine>();

            int engineCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < engineCount; i++)
            {
                string[] parameters = Console.ReadLine()
                                      .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string model = parameters[0];
                int power = int.Parse(parameters[1]);

                int displacement = -1;

                if (parameters.Length == 3 && int.TryParse(parameters[2], out displacement))
                {
                    Engine engine = new Engine(model, power, displacement);
                    engines.Add(engine);
                }
                else if (parameters.Length == 3)
                {
                    string efficiency = parameters[2];
                    Engine engine = new Engine(model, power, efficiency);
                    engines.Add(engine);
                }
                else if (parameters.Length == 4)
                {
                    displacement = int.Parse(parameters[2]);
                    string efficiency = parameters[3];
                    Engine engine = new Engine(model, power, displacement, efficiency);
                    engines.Add(engine);
                }
                else
                {
                    Engine engine = new Engine(model, power);
                    engines.Add(engine);
                }
            }

            int carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string model = parameters[0];
                string engineModel = parameters[1];

                Engine engine = engines.FirstOrDefault(x => x.Model == engineModel); // x.model

                int weight = -1;

                if (parameters.Length == 3 && int.TryParse(parameters[2], out weight))
                {
                    Car car = new Car(model, engine, weight);
                    cars.Add(car);
                }
                else if (parameters.Length == 3)
                {
                    string color = parameters[2];
                    Car car = new Car(model, engine, color);
                    cars.Add(car);
                }
                else if (parameters.Length == 4)
                {
                    weight = int.Parse(parameters[2]);
                    string color = parameters[3];
                    Car car = new Car(model, engine, weight, color);
                    cars.Add(car);
                }
                else
                {
                    Car car = new Car(model, engine);
                    cars.Add(car);
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }

}
