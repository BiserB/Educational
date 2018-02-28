using System;
using System.Linq;

namespace L3
{
    class Program
    {
        static void Main()
        {
            string[] text = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string[] result = text.Where(w => w.First() > 64 && w.First() < 91).ToArray();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            
        }
    }
}
