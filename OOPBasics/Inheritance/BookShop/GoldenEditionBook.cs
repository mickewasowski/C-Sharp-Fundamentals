using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop
{
    public class GoldenEditionBook : Book
    {
        public GoldenEditionBook(string author, string title, double price) : base(author, title, price)
        {
        }
        public override double Price
        {
            get
            {
                return base.Price * 1.3;
            }
        }
    }
}
