using System;


public class Program
{
    public static int n = 0;

    static void Main()
    {
        n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            PrintRow(i);
        }
        for (int i = n - 1; i >= 1; i--)
        {
            PrintRow(i);
        }
    }
    static void PrintRow(int row)
    {
        Console.Write(new String(' ', n - row) );
        for (int i = 0; i < row; i++)
        {
            Console.Write("* ");
        }
        Console.WriteLine();
    }
}
