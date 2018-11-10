using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        private string model;
        private decimal fuelAmount;
        private decimal fuelConsumption;
        private decimal distanceToTravell;

        public Car(string model, int fuelAmount, decimal fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumption = fuelConsumption;
            this.TravelledDistance = 0;
        }

        public void DriveCalculation(decimal distance)
        {
            if (this.fuelAmount < distance * this.fuelConsumption)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                this.fuelAmount -= distance * this.fuelConsumption;
                this.TravelledDistance += distance;
            }
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }
        public decimal FuelAmount
        {
            get
            {
                return this.fuelAmount;
            }
            set
            {
                this.fuelAmount = value;
            }
        }
        public decimal FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }
            set
            {
                this.fuelConsumption = value;
            }
        }
        public decimal TravelledDistance
        {
            get
            {
                return this.distanceToTravell;
            }
            set
            {
                this.distanceToTravell = value;
            }
        }
    }
}

