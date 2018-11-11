using System;
using System.Collections.Generic;

namespace _07
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            char[] openParenthesis = new char[] { '(', '{', '[' };

            Stack<char> parenthesis = new Stack<char>();

            bool isValid = true;

            for (int i = 0; i < input.Length; i++)
            {
                char currBracket = input[i];

                if (currBracket == openParenthesis[0])
                {
                    parenthesis.Push(currBracket);
                    continue;
                }
                else if (currBracket == openParenthesis[1])
                {
                    parenthesis.Push(currBracket);
                    continue;
                }
                else if (currBracket == openParenthesis[2])
                {
                    parenthesis.Push(currBracket);
                    continue;
                }
                if (parenthesis.Count > 0)
                {
                    if (parenthesis.Peek() == openParenthesis[0] && currBracket == ')')
                    {
                        parenthesis.Pop();
                        continue;
                    }
                    else if (parenthesis.Peek() == openParenthesis[1] && currBracket == '}')
                    {
                        parenthesis.Pop();
                        continue;
                    }
                    else if (parenthesis.Peek() == openParenthesis[2] && currBracket == ']')
                    {
                        parenthesis.Pop();
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    isValid = false;
                    break;
                }
            }

            if (parenthesis.Count == 0 && isValid)
            {
            Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
