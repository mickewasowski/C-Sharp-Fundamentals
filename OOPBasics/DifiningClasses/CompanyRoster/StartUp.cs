namespace CompanyRoster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                //Pesho 120.00 Dev Development pesho@abv.bg 28
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                decimal salary = Decimal.Parse(input[1]);
                string position = input[2];
                string department = input[3];

                Employee employee = new Employee(name, salary, position, department);

                if (input.Length == 5)
                {
                    if (input[4].Contains("@")) // ????
                    {
                        employee.Email = input[4];
                    }
                    else
                    {
                        employee.Age = int.Parse(input[4]);
                    }
                }
                else if (input.Length == 6)
                {
                    employee.Email = input[4];
                    employee.Age = int.Parse(input[5]);
                }

                employees.Add(employee);
            }
            var topDepartment = employees.GroupBy(x => x.Department) // we group them by the department
                                         .ToDictionary(x => x.Key, y => y.Select(s => s)) // we take the result to a dictionary with our department as a key and the employee info as value
                                         .OrderByDescending(x => x.Value.Average(s => s.Salary)) // we order our employees by their average salary
                                         .FirstOrDefault(); // we take the first or default occurence 

            Console.WriteLine($"Highest Average Salary: {topDepartment.Key}");
            foreach (var employee in topDepartment.Value.OrderByDescending(s => s.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2} {employee.Email} {employee.Age}");
            }
        }
    }
}
