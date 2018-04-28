using System;
using System.Collections.Generic;
using System.Linq;

namespace t03_ListIterator
{
    public class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            string[] data = input.Split().Skip(1).ToArray();

            ListIterator li = new ListIterator(data);           

            while ((input = Console.ReadLine()) != "END")
            {
                string result = "";

                try
                {
                    switch (input)
                    {

                        case "HasNext":
                            result = li.HasNext().ToString();
                            break;

                        case "Move":
                            result = li.Move().ToString();
                            break;

                        case "Print":
                            result = li.Print().ToString();
                            break;
                    }
                    Console.WriteLine(result);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine(ane.Message);
                }

            }
        }
    }
}
