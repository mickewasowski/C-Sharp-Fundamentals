using System;
using System.Collections.Generic;
using System.Linq;

namespace _09
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string text = "";

            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                string command = input[0];

                switch (command)
                {
                    case "1":
                        stack.Push(text);

                        string newText = input[1];
                        text += newText;
                        break;
                    case "2":
                        stack.Push(text);

                        int count = int.Parse(input[1]);
                        text = text.Substring(0, text.Length - count); // ????
                        break;
                    case "3":
                        int index = int.Parse(input[1]);

                        Console.WriteLine(text[index - 1]);
                        break;
                    case "4":
                        text = stack.Pop();
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
