using System;
using System.Linq;

public class Program
{
    static void Main()
    {        
        int[] coordinate = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Point topLeft = new Point(coordinate[0], coordinate[1]);
        Point bottomRight = new Point(coordinate[2], coordinate[3]);
        var rectangle = new Rectangle(topLeft, bottomRight);

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Point pointToCheck = new Point(data[0], data[1]);
            Console.WriteLine(rectangle.Contains(pointToCheck));
        }
    }
}
