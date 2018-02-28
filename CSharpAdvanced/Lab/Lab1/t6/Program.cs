using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace t6
{
    class Program
    {
        static void Main()
        {
            Queue<string> register = new Queue<string>();
            int num = int.Parse(Console.ReadLine());
            string input = Console.ReadLine().Trim();
            int greenCnt = 0;

            while (input != "end")
            {
                if (input == "green")
                {
                    greenCnt++;                
                }
                else
                {
                    register.Enqueue(input);                    
                }
                input = Console.ReadLine();
            }
            int count = 0;
            while (greenCnt > 0)
            {
                for (int i = 0; i < num; i++)
                {
                    if (register.Count > 0)
                    {
                        Console.WriteLine(register.Dequeue() + " passed!");
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
                greenCnt--;
            }                              
            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
