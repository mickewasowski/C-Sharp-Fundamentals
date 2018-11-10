namespace DateModifier
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    public class DateModifier
    {
        public static void DateInDays(string dateOne, string dateTwo)
        {
            DateTime firtsDate = DateTime.ParseExact(dateOne, "yyyy MM dd", CultureInfo.InvariantCulture);
            DateTime secondDate = DateTime.ParseExact(dateTwo, "yyyy MM dd", CultureInfo.InvariantCulture);

            TimeSpan difference = firtsDate.Subtract(secondDate);
            Console.WriteLine(Math.Abs(difference.TotalDays));
        } 
    }
}
