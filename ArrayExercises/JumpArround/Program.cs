using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpArround
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int index = data[0];
            int sum = index;
            while (index < data.Length && index >= 0)
            {
                int number = data[index];   // this is the value of data[] on new position "index"
                sum += number;

                index += number;            // this is the new position to the right by "number"
                if (index >= data.Length)
                {
                    index = index - (2 * number); // this is the new position to the left by "number"
                    if (index < 0)
                    {
                        break;
                    }                    
                }
                
            }
            Console.WriteLine(sum);
        }
    }
}
