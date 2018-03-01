using System;


class Program
{
    static void Main()
    {
        string figure = Console.ReadLine();
        if (figure == "Square")
        {
            int size = int.Parse(Console.ReadLine());
            Draw(size, size);
        }
        else if (figure == "Rectangle")
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            Draw(width, height);
        }
    }

    private static void Draw(int width, int height)
    {
        for (int h = 0; h < height; h++)
        {
            Console.Write("|");
            for (int w = 0; w < width; w++)
            {
                if (h == 0 || h == height-1)
                {
                    Console.Write("-");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine("|");            
        }
    }
}
