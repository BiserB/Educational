using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main()
    {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int length = arr.Length;

        for (int i = 0; i < length - 1; i++)
        {            
            int minIndex = i;

            for (int j = i + 1; j < length; j++)
            {
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;                    
                }
            }

            if (minIndex != i)
            {
                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }
        }

        Console.WriteLine(string.Join(" ", arr));
    }
}
