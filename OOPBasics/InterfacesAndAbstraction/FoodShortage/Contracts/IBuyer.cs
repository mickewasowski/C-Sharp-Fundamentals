using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Contracts
{
    public interface IBuyer
    {
        void BuyFood();

        string Name { get; }

        int Food { get; }
    }
}
