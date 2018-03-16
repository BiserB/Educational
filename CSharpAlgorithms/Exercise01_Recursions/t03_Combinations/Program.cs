// Write a recursive program for generating and printing all combinations 
// with duplicates of k elements from a set of n elements (k <= n).

using System;
using System.Collections.Generic;


public class Program
{
    //private static int start = 1;

    static void Main()
    {        
        int end = int.Parse(Console.ReadLine());
        int range = int.Parse(Console.ReadLine());
        
        int[] arr = new int[range];

        FillArr(arr, 0, end);
    }

    private static void FillArr(int[] arr, int index, int end)
    {
        int start = 1;

        if (index == arr.Length)
        {
            Console.WriteLine(string.Join(" ", arr));
            if (arr[arr.Length - 1] == end)
            {
                //start++;
            }
            return;
        }
        else
        {
            for (int i = start; i <= end; i++)
            {
                arr[index] = i;
                FillArr(arr, index + 1, end);
            }
        }            
    }
}
