using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Models
{
    public class Kitten : Cat
    {
        //Meow
        private const string gender = "Female";

        public Kitten(string name, int age) 
            : base(name, age, gender)
        {
        }    
        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }
    }
}
