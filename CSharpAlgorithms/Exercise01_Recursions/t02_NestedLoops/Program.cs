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
        for (int i = 0; i < arr.Length; i++)
        {
            arr[index] = i + 1;
            Loop(arr, index + 1);
        }
    }
}
