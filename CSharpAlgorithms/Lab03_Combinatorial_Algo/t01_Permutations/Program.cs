//  Permutations without Repetitions

using System;


public class Program
{
    private static string[] set;
    private static string[] result;
    private static bool[] used;
    private static int length;

    static void Main()
    {
        set = Console.ReadLine().Split();
        length = set.Length;
        result = new string[length];
        used = new bool[length];

        GeneratePermutation(0);
    }

    private static void GeneratePermutation(int index)
    {
        if (index >= length)
        {
            Print();
        }
        else
        {
            for (int i = 0; i < length; i++)
            {
                if (used[i] == false)
                {
                    result[index] = set[i];                    
                    used[i] = true;
                    GeneratePermutation(index + 1);
                    used[i] = false;
                }
            }
        }
    }

    private static void Print()
    {
        Console.WriteLine(string.Join(" ", result));
    }
}
