using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumARR
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] arr2 = Console.ReadLine().Split().Select(int.Parse).ToArray();            
            
            Console.WriteLine(string.Join(" ", Sum(arr1, arr2)));
        }
        static int[] Sum(int[] arr1, int[] arr2)
        {            
            int length1 = arr1.Length;
            int length2 = arr2.Length;
            int diff = length1 - length2;
            int max = Math.Max(length1, length2);
            int[] result = new int[max];
            if (diff == 0)
            {
                for (int i = 0; i < length1; i++)
                {
                    result[i] = arr1[i] + arr2[i];
                }
            }
            else if (diff > 0)
            {
                int j = 0;
                for (int i = 0; i < length1; i++)
                {
                    if (j == length2)
                    {
                        j = 0;
                    }
                    result[i] = arr1[i] + arr2[j];
                    j++;
                }
            }
            else if (diff < 0)
            {
                int j = 0;
                for (int i = 0; i < length2; i++)
                {
                    if (j == length1)
                    {
                        j = 0;
                    }
                    result[i] = arr2[i] + arr1[j];
                    j++;
                }
            }
            return result;
        }
    }
}
