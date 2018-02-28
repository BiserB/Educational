using System;

namespace L4_2
{
    class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            UInt64[][] triangle = new UInt64[num][] ;

            triangle[0] = new UInt64[] { 1 };
            triangle[1] = new UInt64[] { 1 , 1};

            for (int i = 2; i < num; i++)
            {

            }
        }
    }
}
