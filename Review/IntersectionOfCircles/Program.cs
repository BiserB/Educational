using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectionOfCircles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Point center1 = new Point
            {
                X = input1[0],
                Y = input1[1]
            };
            Circle c1 = new Circle
            {
                Center = center1,
                Radius = input1[2]
            };
            Point center2 = new Point
            {
                X = input2[0],
                Y = input2[1]
            };
            Circle c2 = new Circle
            {
                Center = center2,
                Radius = input2[2]
            };
            if (Intersect(c1, c2))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
        public static bool Intersect(Circle c1, Circle c2)
        {
            int x1 = c1.Center.X;
            int y1 = c1.Center.Y;
            int x2 = c2.Center.X;
            int y2 = c2.Center.Y;
            double d = 0.0d;
            d = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
            if (d <= (c1.Radius + c2.Radius))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    class Circle
    {
        public Point Center { get; set; }
        public int Radius { get; set; }
    }
}
