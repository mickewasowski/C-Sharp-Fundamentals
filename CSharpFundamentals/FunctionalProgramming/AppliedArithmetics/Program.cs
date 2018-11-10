using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            //Func<int[], int[]> addOne = nums => nums.Select(x => x + 1).ToArray();
            //Func<int[], int[]> subtractByOne = nums => nums.Select(x => x - 1).ToArray();
            //Func<int[], int[]> multiplyByTwo = nums => nums.Select(x => x * 2).ToArray();
            //Action<int[]> print = p => Console.WriteLine(string.Join(" ",p));

            //int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            string command = Console.ReadLine();

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            Func<int, int> add = num => num+=1;
                            numbers[i] = add(numbers[i]);

                            //numbers = addOne(numbers);
                        }
                        break;
                    case "multiply":
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            Func<int, int> multiply = num => num*=2;
                            numbers[i] = multiply(numbers[i]);

                            //numbers = multiplyByTwo(numbers);
                        }
                        break;
                    case "subtract":
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            Func<int, int> subtract = num => num-=1;
                            numbers[i] = subtract(numbers[i]);

                            //numbers = subtractByOne(numbers);
                        }
                        break;
                    case "print":
                        Action<int> print = num => Console.Write(num + " ");
                        foreach (var nuM in numbers)
                        {
                            print(nuM);
                        }
                        Console.WriteLine();

                        //print(numbers);
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine();
            }
        }
 
    }
}
