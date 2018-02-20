using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Enter a day number [1…7] and print the day name (in English) or “Invalid Day!”. Use an array of strings.


namespace DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] days = { "","Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            uint num = uint.Parse(Console.ReadLine());
            while (num > 0 && num < 8)
            {
                Console.WriteLine(days[num]);
                num = uint.Parse(Console.ReadLine());
            }
        }

    }
}
