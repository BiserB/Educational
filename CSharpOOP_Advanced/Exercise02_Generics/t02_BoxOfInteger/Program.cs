using System;


public class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int data = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>(data);
            Console.WriteLine(box);
        }        
    }
}
