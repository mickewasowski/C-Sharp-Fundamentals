using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind
{
    public class Worker : Human
    {
        private double weekSalary;
        private double workHours;

        public Worker(string firstName,string lastName,double weekSalary,double workHours) : base(firstName,lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHours = workHours;
        }

        public double WeekSalary
        {
            get => weekSalary;
            set
            {
                if (value < 10)
                {
                    Console.WriteLine(ExceptionMesseges.WeekSalaryAmount);
                    Environment.Exit(1);
                }
                weekSalary = value;
            }
        }
        public double WorkHours
        {
            get => workHours;
            set
            {
                if (value < 1 || value > 12)
                {
                    Console.WriteLine(ExceptionMesseges.WorkHoursRange);
                    Environment.Exit(1);
                }
                workHours = value;
            }
        }

        public override string ToString()
        {
            double salaryPerHour = (this.weekSalary / 5) / this.workHours;

            var worker = new StringBuilder();
            worker.AppendLine($"First Name: {FirstName}")
                .AppendLine($"Last Name: {LastName}")
                .AppendLine($"Week Salary: {WeekSalary:f2}")
                .AppendLine($"Hours per day: {WorkHours:f2}")
                .AppendLine($"Salary per hour: {salaryPerHour:f2}");

            string result = worker.ToString();

            return result;
        }
    }
}
