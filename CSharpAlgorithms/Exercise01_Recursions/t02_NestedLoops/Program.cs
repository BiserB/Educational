// A program that simulates the execution of n nested loops from 1 to n which prints the values
//  of all its iteration variables at any given time on a single line.

using System;

public class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        Loop(arr, 0);
    }

    private static void Loop(int[] arr, int index)
    {
        if (index >= arr.Length)
        {
            Console.WriteLine(string.Join(" ", arr));
            return;
        }
        for (int i = 1; i <= arr.Length; i++)
        {
            arr[index] = i;
            Loop(arr, index + 1);
        }
    }
}
