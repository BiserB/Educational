using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace t05_Needles_II
{
    public class Program
    {
        static List<int> result = new List<int>();

        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            List<int> needles = Console.ReadLine().Split().Select(int.Parse).ToList();

            int numLength = numbers.Length;
            

            foreach (var needle in needles)
            {

                bool match = false;

                for (int i = 0; i < numLength; i++)
                {
                    if (needle <= numbers[i])
                    {
                        match = true;
                        ChechForZero(numbers, i - 1);
                        break;
                    }
                }

                if (!match)
                {
                    ChechForZero(numbers, numbers.Length - 1);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }

        private static void ChechForZero(int[] numbers, int index)
        {
            while (index >= 0)
            {               
                if (numbers[index] != 0)
                {
                    result.Add(index + 1);
                    return;
                }
                index--;
            }

            result.Add(0);
        }
    }
}
