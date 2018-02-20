using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int max = data.Max();
            int min = data.Min();
            double avg = data.Average();

            Console.WriteLine("Max = "+ max);
            Console.WriteLine("Min = "+ min);
            Console.WriteLine("Sum = "+ data.Sum());
            Console.WriteLine("AVG = "+ avg);
        }
    }
}
