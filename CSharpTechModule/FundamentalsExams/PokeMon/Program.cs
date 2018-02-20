using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int power = int.Parse(Console.ReadLine());
            double halfPower = power / 2.0 ;
            int distance = int.Parse(Console.ReadLine());
            int exhaustion = int.Parse(Console.ReadLine());
            int cnt = 0;
            while (power >= distance)
            {
                power -= distance;
                cnt++;

                if (power == halfPower)
                {
                    if (exhaustion > 0  && power >= 0 )
                    {
                        power = power / exhaustion;
                    }                    
                }
               
            }
            Console.WriteLine(power);
            Console.WriteLine(cnt);
        }
    }
}
