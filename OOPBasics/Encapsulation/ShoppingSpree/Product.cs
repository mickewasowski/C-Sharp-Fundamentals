using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name,decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string  Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null)
                {
                    Console.WriteLine("Name cannot be empty");
                    Environment.Exit(1);
                }
                this.name = value;
            }
        }
        public decimal Cost
        {
            get
            {
                return this.cost;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Money cannot be negative");
                    Environment.Exit(1);
                }
                this.cost = value;
            }
        }
    }
}
