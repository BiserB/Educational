// Write a recursive program for generating and printing all combinations 
// with duplicates of k elements from a set of n elements (k <= n).

using System;
using System.Collections.Generic;


public class Program
{
    
    static void Main()
    {        
        int endNum = int.Parse(Console.ReadLine());
        int range = int.Parse(Console.ReadLine());
        
        int[] arr = new int[range];

        for (int startNum = 1; startNum <= endNum; startNum++)
        {
            FillArr(arr, 0, startNum, endNum);
        }

        
    }

    private static void FillArr(int[] arr, int index, int startNum, int endNum)
    {
        
        if (index == arr.Length)
        {
            Console.WriteLine(string.Join(" ", arr));            
            return;
        }
        else
        {
            for (int i = startNum; i <= endNum; i++)
            {
                arr[index] = i;
                FillArr(arr, index + 1, startNum, endNum);
            }
        }            
    }
}
