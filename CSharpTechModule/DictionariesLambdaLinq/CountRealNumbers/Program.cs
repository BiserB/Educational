using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> input = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
            Dictionary<double, uint> result = new Dictionary<double, uint>();
            foreach (double item in input)
            {
                if (!result.ContainsKey(item))
                {
                    result[item] = 0;
                }
                result[item] += 1;
            }
            foreach (KeyValuePair<double, uint> item in result.OrderBy(p => p.Key))
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
        }
    }
}
