using System;

class CombinationsGenerator
{
    static void Main()
    {
        int n = 2;
        int startNum = 1;
        int endNum = 3;

        int[] arr = new int[n];
        GenCombs(arr, 0, startNum, endNum);
    }

    static void GenCombs(int[] arr, int index, int startNum, int endNum)
    {
        if (index >= arr.Length)
        {
            // A combination was found --> print it
            Console.WriteLine("(" + string.Join(", ", arr) + ")");
        }
        else
        {
            for (int i = startNum; i <= endNum; i++)
            {
                arr[index] = i;
                GenCombs(arr, index + 1, i + 1, endNum);
            }
        }
    }
}
