using System;
using System.Collections.Generic;
using System.Linq;

namespace t11_2
{
    class Program
    {
        static void Main()
        {            
            int cnt = int.Parse(Console.ReadLine());            
            int[] input = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();            
            int previous = input[0];                              // first plant
            Stack<int> survivedPlants = new Stack<int>();         // list of survived plants
            survivedPlants.Push(previous);                        // first plant always survive
            int[] days = new int[cnt];                            // keep track of days untill plant die
            days[0] = 0;                                          // first plant never die (0 days)

            for (int i = 1; i < cnt; i++)
            {
                int current = input[i];
                if (current > previous)                         // plant will die after 1 day 
                {                    
                    days[i] = 1;                    
                }
                else if (current > survivedPlants.Peek())       // plant will die after more than 1 day
                {
                   
                    int num = 1;                                // with this number will go back through input[]
                    int d = 0;
                    while (current <= previous)
                    {
                        d = days[i - num];                      // get days on previous plant
                        num++;
                        previous = input.ElementAt(i - num);                        
                    }
                    days[i] = d + 1;                            // current plant will die 1 day after calculatedPlant
                }
                else
                {
                    survivedPlants.Push(current);         // plant survived
                    days[i] = 0;                         // 0 for survived plant
                }
                previous = current;                     // update previous number for next comparision
            }
            Console.WriteLine(String.Join(' ', days));
            Console.WriteLine(days.Max());
        }
    }
}
