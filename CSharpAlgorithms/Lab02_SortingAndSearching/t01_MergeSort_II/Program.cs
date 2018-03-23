using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace t01_MergeSort_II
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] reversed = arr.Reverse().ToArray();

            Sort(reversed, 0, arr.Length - 1);

            Console.WriteLine(string.Join(" ", reversed));
        }
   
        static void Sort(int[] arr, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }

            int middleIndex = (startIndex + endIndex) / 2;

            Sort(arr, startIndex, middleIndex);         // left part
            Sort(arr, middleIndex + 1 , endIndex);      // right part

            Merge(arr, startIndex, middleIndex, endIndex);
        }

        private static void Merge(int[] arr, int startIndex, int middleIndex, int endIndex)
        {
            if (middleIndex < 0 || middleIndex + 1 > arr.Length - 1 ||
                arr[middleIndex] <= arr[middleIndex + 1])
            {
                return;
            }

            int[] aux = new int[arr.Length];
            for (int i = startIndex; i <= endIndex; i++)
            {
                aux[i] = arr[i];
            }
            int leftIndex = startIndex;
            int rightIndex = middleIndex + 1;

            for (int i = startIndex; i <= endIndex; i++)
            {
                if (leftIndex > middleIndex )
                {
                    arr[i] = aux[rightIndex++];
                }
                else if (rightIndex > endIndex)
                {
                    arr[i] = aux[leftIndex++];
                }
                else if (aux[leftIndex] <= aux[rightIndex])
                {
                    arr[i] = aux[leftIndex++];
                }
                else 
                {
                    arr[i] = aux[rightIndex++];
                }
            }
        }

       
    }
}
