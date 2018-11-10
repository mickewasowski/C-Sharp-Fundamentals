using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            //Action<List<int>> reversedFunc = nums => nums.Reverse();
               //after reading the List<int> from the console
               //reversedFunc(numbers);
            
            List<int> list = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int divide = int.Parse(Console.ReadLine());

            Func<List<int>, List<int>> reverse = GetReversedList;

            list = reverse(list);

            Func<List<int>,int, List<int>> exclude = GetExcludedList;

            list = exclude(list, divide);

            Console.WriteLine(string.Join(" ",list));
        }

        private static List<int> GetExcludedList(List<int> list,int divide)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (list[i] % divide == 0)
                {
                    list.RemoveAt(i);
                }
            }
            return list;
        }

        private static List<int> GetReversedList(List<int> list)
        {
            List<int> reversed = new List<int>();
            for (int i = list.Count - 1; i >= 0; i--)
            {
                reversed.Add(list[i]);
            }
            list.Clear();
            for (int i = 0; i < reversed.Count; i++)
            {
                list.Add(reversed[i]);
            }
            return list;
        }
    }
}
