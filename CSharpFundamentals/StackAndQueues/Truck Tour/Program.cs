using System;
using System.Collections.Generic;
using System.Linq;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int[]> petrolPumps = new Queue<int[]>();
 
            int indexes = 0;
            int totalFuel = 0;

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                petrolPumps.Enqueue(input);
            }

            while (true)
            {
                totalFuel = 0;

                foreach (var currPetrolPump in petrolPumps)
                {
                    int fuel = currPetrolPump[0];
                    int distance = currPetrolPump[1];

                    totalFuel += fuel - distance;

                    if (totalFuel < 0)
                    {
                        int[] pumpRemove = petrolPumps.Dequeue();
                        petrolPumps.Enqueue(pumpRemove);

                        indexes++;
                        break;
                    }                 
                }
                if (totalFuel >= 0)
                {
                    break;
                }
            }
            Console.WriteLine(indexes);         
        }
    }
}
