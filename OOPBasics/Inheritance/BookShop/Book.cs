using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop
{
    public class Book
    {
        private string title;
        private string author;
        private double price;

        public Book(string author,string title,double price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        public virtual string Title
        {
            get => this.title;
            set
            {
                if (value.Length < 3)
                {
                    Console.WriteLine(ExceptionMessages.InvalidTitle);
                    Environment.Exit(1);
                }
                this.title = value;
            }
        }
        public virtual string Author
        {
            get => this.author;
            set
            {
                //Направи един сплит на стринга по спейс и една if проверка, ако дължината на масива е по-голяма от 1, 
                //тогава проверявай второто име от сплита. Да ли не е null на първо място, празен стринг и тогава за число.

                string[] input = value.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input.Length > 1)
                {
                    if (char.IsDigit(input[1][0]) || string.IsNullOrEmpty(input[1]) || string.IsNullOrWhiteSpace(input[1]))
                    {//input[1] => взимаме втория елемент от масива, 
                     //input[1][0] => разглеждаме елемента като стринга и от стринга вече взимаме първия елемент

                        Console.WriteLine(ExceptionMessages.InvalidName);
                        Environment.Exit(1);
                    }
                }

                this.author = value;
            }
        }
        public virtual double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine(ExceptionMessages.InvalidPrice);
                    Environment.Exit(1);
                }
                this.price = value;
            }
        }
        public override string ToString()
        {
            var resultBuilder = new StringBuilder();
            resultBuilder.AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Title: {this.Title}")
                .AppendLine($"Author: {this.Author}")
                .AppendLine($"Price: {this.Price:f2}");

            string result = resultBuilder.ToString().TrimEnd();
            return result;
        }
    }
}
