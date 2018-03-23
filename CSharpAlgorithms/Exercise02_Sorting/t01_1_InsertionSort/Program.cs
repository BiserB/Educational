using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace t01_1_InsertionSort
{
    public class Program
    {
        private static int[] arr;

        static void Main()
        {
            arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int index = 1;
            Sort(index, arr);
            Console.WriteLine(string.Join(" ", arr));
        }

        private static void Sort(int index, int[] arr)
        {
            if (index == 0 || index == arr.Length)
            {
                return;
            }
            if (arr[index] < arr[index - 1])
            {
                Swap(index);
                Sort(index - 1, arr);
                Sort(index + 1, arr);
            }
            else
            {
                Sort(index + 1, arr);
            }            
        }

        private static void Swap(int index)
        {
            int temp = arr[index];
            arr[index] = arr[index - 1];
            arr[index - 1] = temp;
        }
    }
}
