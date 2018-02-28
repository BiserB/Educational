using System;

namespace FindDegree
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int angle = int.Parse(Console.ReadLine());
                int quadrant = (angle / 90) % 4 ; // Quadrant
                Console.WriteLine("quadrant = " + quadrant);
            }
            
        }
    }
}
