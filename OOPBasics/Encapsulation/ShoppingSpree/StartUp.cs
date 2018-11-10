using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] people = Console.ReadLine().Split(new char[] { '=', ';' },StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] products = Console.ReadLine().Split(new char[] { '=', ';' },StringSplitOptions.RemoveEmptyEntries).ToArray();

            
            var grocery = new Dictionary<Person, List<Product>>();

            List<Product> currProducts = new List<Product>();

            for (int p = 0; p < people.Length; p+=2)
            {
                string person = people[p];
                decimal money = decimal.Parse(people[p+1]);
                Person personTokens = new Person(person,money);

                for (int g = 0; g < products.Length; g+=2)
                {
                    string product = products[g];
                    decimal cost = decimal.Parse(products[g+1]);

                    Product productTokens = new Product(product, cost);

                    currProducts.Add(productTokens);


                    if (grocery.ContainsKey(personTokens))
                    {
                        grocery[personTokens] = currProducts;
                    }
                    else
                    {
                        grocery.Add(personTokens, currProducts);
                    }
                }
            }

            string input = Console.ReadLine();


            var stuffBought = new Dictionary<string, string>();

            while (input != "END")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string personName = command[0];
                string productName = command[1];

                foreach (var p in grocery)
                {
                    string name = p.Key.Name;
                    decimal money = p.Key.Money;

                    decimal moneyValidation = 0;

                    foreach (var i in currProducts)
                    {
                        string product = i.Name;
                        decimal cost = i.Cost;

                        if (personName == name && product == productName)
                        {
                            moneyValidation = money - cost;

                            if (moneyValidation >= 0)
                            {
                                if (stuffBought.ContainsKey(personName))
                                {
                                    stuffBought[personName] = productName;
                                }
                                else
                                {
                                    stuffBought.Add(personName, productName);
                                }

                                Console.WriteLine($"{name} bought {product}");
                            }
                            else
                            {
                                stuffBought.Add(personName, "0");

                                Console.WriteLine($"{name} can't afford {product}");
                            }
                        }
                    }
                }
                input = Console.ReadLine();
            }

            if (stuffBought.Count > 0)
            {
                foreach (var item in stuffBought)
                {
                    if (item.Value == "0")
                    {
                        Console.WriteLine($"{item.Key} – Nothing bought");
                    }
                    else
                    {
                        Console.Write(string.Join(", ",item.Value));
                    }
                }
                
            }

            //dictionary<person, List<products>

        }
    }
}
