using System;
using System.Linq;
using System.Collections.Generic;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ").ToArray();
                string color = input[0];
                string[] clothes = input[1].Split(',').ToArray();

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());                    
                }
                for (int j = 0; j < clothes.Length; j++)
                {
                    string currClothing = clothes[j];

                    if (!wardrobe[color].ContainsKey(currClothing))
                    {
                        wardrobe[color].Add(currClothing, 0);
                    }

                    wardrobe[color][currClothing] += 1; 
                }

            }
            string[] target = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string targetColor = target[0];
            string targetClothing = target[1];


            foreach (var kvp in wardrobe)
            {
                Console.WriteLine($"{kvp.Key} clothes:");

                foreach (var item in kvp.Value)
                {
                    Console.Write($"* {item.Key} - {item.Value}");

                    if (kvp.Key == targetColor && item.Key == targetClothing)
                    {
                        Console.Write(" (found!)");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
