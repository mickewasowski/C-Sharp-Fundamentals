using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind
{
    public class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName,string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get => this.firstName;
            set
            {
                //fullUri.Any(char.IsUpper);
                string first = value.ToString();
                if (!char.IsUpper(first[0]))
                {
                    Console.WriteLine(ExceptionMesseges.FirstNameCapitalLetter);
                    Environment.Exit(1);
                }
                if (value.Length < 4)
                {
                    Console.WriteLine(ExceptionMesseges.FirstNameLength);
                    Environment.Exit(1);
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get => this.lastName;
            set
            {
                string last = value.ToString();

                if (!char.IsUpper(last[0]))
                {
                    Console.WriteLine(ExceptionMesseges.LastNameCapitalLetter);
                    Environment.Exit(1);
                }
                if (value.Length < 3)
                {
                    Console.WriteLine(ExceptionMesseges.LastNameLength);
                    Environment.Exit(1);
                }
                this.lastName = value;
            }
        }
    }
}
