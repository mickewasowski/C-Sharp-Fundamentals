using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class StartUp
    {
        static void Main(string[] args)
        {
            long input = long.Parse(Console.ReadLine());
            string[] cashBox = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();
            long gold = 0;
            long rocks = 0;
            long money = 0;

            for (int i = 0; i < cashBox.Length; i += 2)
            {
                string name = cashBox[i];
                long count = long.Parse(cashBox[i + 1]);

                string token = string.Empty;

                if (name.Length == 3)
                {
                    token = "Cash";
                }
                else if (name.ToLower().EndsWith("gem"))
                {
                    token = "Gem";
                }
                else if (name.ToLower() == "gold")
                {
                    token = "Gold";
                }

                if (token == "")
                {
                    continue;
                }
                else if (input < bag.Values.Select(x => x.Values.Sum()).Sum() + count)
                {
                    continue;
                }

                switch (token)
                {
                    case "Gem":
                        if (!bag.ContainsKey(token))
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (count > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[token].Values.Sum() + count > bag["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!bag.ContainsKey(token))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (count > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[token].Values.Sum() + count > bag["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                }

                if (!bag.ContainsKey(token))
                {
                    bag[token] = new Dictionary<string, long>();
                }

                if (!bag[token].ContainsKey(name))
                {
                    bag[token][name] = 0;
                }

                bag[token][name] += count;
                if (token == "Gold")
                {
                    gold += count;
                }
                else if (token == "Gem")
                {
                    rocks += count;
                }
                else if (token == "Cash")
                {
                    money += count;
                }
            }

            foreach (var x in bag)
            {
                Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
                foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }
    }
}