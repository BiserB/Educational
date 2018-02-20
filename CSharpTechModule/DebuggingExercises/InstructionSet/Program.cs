using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstructionSet
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] action = input.Split(' ');
                long result = 0;
                switch (action[0])
                {
                    case "INC":
                        {
                            long operandOne = long.Parse(action[1]);
                            result = ++operandOne ;
                            break;
                        }
                    case "DEC":
                        {
                            long operandOne = long.Parse(action[1]);
                            result = --operandOne;
                            break;
                        }
                    case "ADD":
                        {
                            long operandOne = long.Parse(action[1]);
                            long operandTwo = long.Parse(action[2]);
                            result = operandOne + operandTwo;
                            break;
                        }
                    case "MLA":
                        {
                            long operandOne = long.Parse(action[1]);
                            long operandTwo = long.Parse(action[2]);
                            result = (operandOne * operandTwo);
                            break;
                        }
                }

                Console.WriteLine(result);
                input = Console.ReadLine();
            }
        }
    }
}
