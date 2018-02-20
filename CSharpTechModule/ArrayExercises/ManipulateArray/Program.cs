using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulateArray
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(' ').ToList();
            
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();
                switch (command)
                {
                    case "Reverse":
                        {
                            input.Reverse();
                        }
                    break;
                    case "Distinct":
                        {
                            input = input.Distinct().ToList();
                        }
                        break;
                    default:
                        {
                            string[] replace = command.Split(' ');
                            int index = int.Parse(replace[1]);
                            string word = replace[2];
                            input[index] = word;
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
