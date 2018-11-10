using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public class Ferrari : IDrivable
    {
        private string driver;

        public Ferrari(string driver)
        {
            this.Model = "488-Spider";
            this.Driver = driver;
        }

        public string Model { get ; private set; }
        public string Driver { get => driver; private set => driver = value; }

        public string Brakes()
        {
            return "Brakes!";
        }
        public string Gas()
        {
            return "Zadu6avam sA!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{Brakes()}/{Gas()}/{this.Driver}";
        }
    }
}
