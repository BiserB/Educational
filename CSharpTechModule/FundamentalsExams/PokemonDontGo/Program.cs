using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDontGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> register = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int sum = 0;
            while (register.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());
                int value = 0;

                if (index < 0)
                {
                    value = register[0];
                    register[0] = register[register.Count - 1];                    
                }
                else if (index >= register.Count)
                {
                    value = register[register.Count -1];
                    register[register.Count - 1] = register[0];
                }
                else
                {
                    value = register[index];
                    register.RemoveAt(index);
                }
                sum += value;
                for (int i = 0; i < register.Count; i++)
                {
                    if (register[i] <= value)
                    {
                        register[i] += value;
                    }
                    else
                    {
                        register[i] -= value;
                    }
                }                
            }
            Console.WriteLine(sum);
        }
    }
}
