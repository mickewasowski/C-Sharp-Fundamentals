using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Car[] cars = new Car[n];

            

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] carTokens = input.Split();
                string carModel = carTokens[0];
                int fuelAmount = int.Parse(carTokens[1]);
                decimal fuelConsumption = decimal.Parse(carTokens[2]);

                cars[i] = new Car(carModel, fuelAmount, fuelConsumption);
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] drive = command.Split();
                string model = drive[1];
                decimal kilometers = decimal.Parse(drive[2]);

                cars.Where(c => c.Model == model).ToList().ForEach(c => c.DriveCalculation(kilometers));

                command = Console.ReadLine();
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }

        }
    }
}
