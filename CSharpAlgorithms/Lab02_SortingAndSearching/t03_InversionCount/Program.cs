using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace t03_InversionCount
{
    public class Program
    {
        private static int counter = 0;

        static void Main()
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            InversionCount(arr, 0);           

            Console.WriteLine(counter);
        }

        private static void InversionCount(int[] arr, int start)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        counter++;
                    }
                }
            }
        }       
    }
}
