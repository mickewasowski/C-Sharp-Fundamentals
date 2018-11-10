﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.InfernoIII
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<string> filters = new List<string>();

            string input = Console.ReadLine();

            while (input != "Forge")
            {
                string[] arguments = input.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                string filterName = arguments[0];
                string filterType = arguments[1];
                int num = int.Parse(arguments[2]);

                if (filterName == "Exclude")
                {
                    filters.Add(filterType + ":" + num);
                }
                else if (filterName == "Reverse")
                {
                    filters.Remove(filterType + ":" + num);
                }

                input = Console.ReadLine();
            }

            filters.Reverse();
            Exclude(numbers, filters);

            Console.WriteLine(string.Join(" ", numbers));
        }

        static void Exclude(List<int> numbers, List<string> filters)
        {
            foreach (string filter in filters)
            {
                string[] tokens = filter.Split(':', StringSplitOptions.RemoveEmptyEntries);

                string direction = tokens[0];
                int value = int.Parse(tokens[1]);

                List<int> indexesToDelete = new List<int>();

                switch (direction)
                {
                    case "Sum Left":
                        if (numbers[0] == value)
                        {
                            indexesToDelete.Add(0);
                        }
                        for (int i = 1; i < numbers.Count; i++)
                        {
                            int sum = numbers[i] + numbers[i - 1];

                            if (value == sum)
                            {
                                indexesToDelete.Add(i);
                            }
                        }
                        break;
                    case "Sum Right":
                        if (numbers[numbers.Count - 1] == value)
                        {
                            indexesToDelete.Add(numbers.Count - 1);
                        }
                        for (int i = 0; i < numbers.Count - 1; i++)
                        {
                            int sum = numbers[i] + numbers[i + 1];
                            if (sum == value)
                            {
                                indexesToDelete.Add(i);
                            }
                        }
                        break;
                    case "Sum Left Right":
                        if (numbers.Count > 2)
                        {
                            for (int i = 1; i < numbers.Count - 1; i++)
                            {
                                int sum = numbers[i - 1] + numbers[i] + numbers[i + 1];
                                if (sum == value)
                                {
                                    indexesToDelete.Add(i);
                                }
                            }
                        }
                        else if (numbers.Count >= 2)
                        {
                            if (numbers[0] + numbers[1] == value)
                            {
                                indexesToDelete.Add(0);
                            }

                            if (numbers[numbers.Count - 1] + numbers[numbers.Count - 2] == value)
                            {
                                indexesToDelete.Add(numbers.Count - 1);
                            }
                        }
                        else if (numbers.Count == 1)
                        {
                            if (numbers[0] == value)
                            {
                                indexesToDelete.Add(0);
                            }
                        }

                        
                        break;
                }

                indexesToDelete.Reverse();

                for (int i = numbers.Count - 1; i >= 0; i--)
                {
                    numbers.RemoveAt(indexesToDelete[i]);
                }
            }
        }
    }
}