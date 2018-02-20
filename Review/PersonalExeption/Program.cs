using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalExeption
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int num = int.Parse(input);
            while (num >= 0)
            {
                Console.WriteLine(num);
                num = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("My first exception is awesome!!!");
        }
    }
}
