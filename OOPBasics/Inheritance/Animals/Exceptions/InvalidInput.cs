using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Exceptions
{
    public class InvalidInput : FormatException
    {
        public InvalidInput(string message = "Invalid input!") 
            : base(message)
        {
        }
    }
}
