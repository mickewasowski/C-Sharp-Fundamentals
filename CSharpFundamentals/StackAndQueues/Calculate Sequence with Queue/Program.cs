using System;
using System.Collections.Generic;
using System.Linq;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            Queue<long> queue = new Queue<long>();
            queue.Enqueue(n);

            List<long> list = new List<long>();
            list.Add(n);

            for (int i = 0; i < 17; i++)
            {
                long currNum = queue.Dequeue();

                long a = currNum + 1;
                long b = 2 * currNum + 1;
                long c = currNum + 2;

                queue.Enqueue(a);
                queue.Enqueue(b);
                queue.Enqueue(c);

                list.Add(a);
                list.Add(b);
                list.Add(c);
            }

            Console.WriteLine(String.Join(" ", list.Take(50))); //because they want from us the first 50 elements !!!
        }
    }
}
