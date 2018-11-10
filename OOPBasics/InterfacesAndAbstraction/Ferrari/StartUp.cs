using System;

namespace Ferrari
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string driver = Console.ReadLine();

            Ferrari car = new Ferrari(driver);

            Console.WriteLine(car);
        }
    }
}
