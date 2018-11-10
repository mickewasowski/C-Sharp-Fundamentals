using System;
using System.Linq;

namespace Mankind
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] studentTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string firstName = studentTokens[0];
                string lastName = studentTokens[1];
                string facultyNumber = studentTokens[2];  

                string[] workerTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string workerFirstName = workerTokens[0];
                string workerLastName = workerTokens[1];
                double weekSalary = double.Parse(workerTokens[2]);
                double workHours = double.Parse(workerTokens[3]);

                Student newStudent = new Student(firstName, lastName, facultyNumber);

                Worker worker = new Worker(workerFirstName, workerLastName, weekSalary, workHours);

                Console.WriteLine(newStudent);
                Console.WriteLine(worker);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae);
            }
        }
    }
}
