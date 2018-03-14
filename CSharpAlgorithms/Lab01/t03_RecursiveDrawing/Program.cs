// Write a program that draws the figure below depending on n. Use recursion.

using System;


public class Program
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());

        Draw(num);
    }

    static void Draw(int num)
    {
        if (num == 0)
        {
            return;
        }
        Console.WriteLine(new string('*', num));
        Draw(num - 1);
        Console.WriteLine(new string('#', num));
    }
}
