using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace t05_Needles
{
    public class Program
    {
        static void Main()
        {
            int[] counts = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int c = counts[0];
            int n = counts[1];
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> needles = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> result = new List<int>(n);

            //needles.Sort();
            //needles.Reverse();

            int numCount = numbers.Length;
            //int lastIndex = needles.Count - 1;

            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < numCount; i++)
                {
                    if (needles[j] <= numbers[i])
                    {
                        needles.RemoveAt(0);
                        n--;

                        int index = i - 1;

                        while (index >= 0)
                        {
                            if (numbers[index] == 0)
                            {
                                index--;
                            }
                            else
                            {
                                result.Add(++index);
                                break;
                            }
                        }
                        if (n < 0)
                        {
                            break;
                        }
                    }
                }
            }
            
            
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
