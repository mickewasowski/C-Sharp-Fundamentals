using System;

namespace Telephony
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Smartphone smartphone = new Smartphone();

            string[] inputNums = Console.ReadLine().Split();
            string[] inputURLs = Console.ReadLine().Split();

            for (int i = 0; i < inputNums.Length; i++)
            {
                smartphone.Call(inputNums[i]);
            }

            for (int i = 0; i < inputURLs.Length; i++)
            {
                smartphone.Browse(inputURLs[i]);
            }
        }
    }
}
