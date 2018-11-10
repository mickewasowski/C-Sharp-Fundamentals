using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName,string lastName, string facultyNumber) : base(firstName,lastName)
        {
            this.FacultyNumber = facultyNumber;
        }
        public string FacultyNumber
        {
            get =>this.facultyNumber;
            set
            {
                string chars = value.ToString();
                if (chars.Length < 5 || chars.Length > 10)
                {
                    Console.WriteLine(ExceptionMesseges.FacultyNumberRange);
                    Environment.Exit(1);
                }
                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            var student = new StringBuilder();
            student.AppendLine($"First Name: {FirstName}")
                .AppendLine($"Last Name: {LastName}")
                .AppendLine($"Faculty number: {FacultyNumber}");

            string result = student.ToString();

            return result;
        }
    }
}
