using BirthdayCelebrations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations.Models
{
    public class Pet : IBirthable
    {
        string name;
        string birthdate;

        public Pet(string name,string birthdate)
        {
            this.Name = name;
            this.BirthDate = birthdate;
        }

        public string Name
        {
            get => name;
            private set => name = value;
        }
        public string BirthDate
        {
            get => birthdate;
            private set => birthdate = value;
        }
    }
}
