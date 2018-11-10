namespace DateModifier
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string dateOne = Console.ReadLine();
            string dateTwo = Console.ReadLine();

            DateModifier.DateInDays(dateOne, dateTwo);
        }
    }
}
