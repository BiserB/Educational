using System;

public class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string data = Console.ReadLine();
            Box<string> box = new Box<string>(data);
            Console.WriteLine(box);
        }
    }
}
