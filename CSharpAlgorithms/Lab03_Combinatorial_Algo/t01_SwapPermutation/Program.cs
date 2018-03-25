using System;

class Program
{
    private static string[] set;    
    private static int length;

    static void Main()
    {
        set = Console.ReadLine().Split();
        length = set.Length;        

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
            GeneratePermutation(index + 1);

            for (int i = index + 1; i < length; i++)
            {
                Swap(index, i);
                GeneratePermutation(index + 1);
                Swap(index, i);
            }
        }
    }

    private static void Swap(int index, int i)
    {
        string temp = set[index];
        set[index] = set[i];
        set[i] = temp;
    }

    private static void Print()
    {
        Console.WriteLine(string.Join(" ", set));
    }
}