using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace t5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(' ').ToList();
            int number = int.Parse(Console.ReadLine());
            var names = new Queue<string>();
            foreach (var i in input)
            {
                names.Enqueue(i);
            }
            var result = new Queue<string>();

            while (names.Count > 0)
            {
                string temp = "";
                for (int i = 1; i < number; i++)
                {
                    temp = names.Dequeue();
                    names.Enqueue(temp);
                }
                temp = names.Dequeue();
                result.Enqueue(temp);
            }

            int cnt = result.Count;
            for (int i = 0; i < cnt - 1; i++)
            {
                string n = result.Dequeue();
                Console.WriteLine($"Removed {n}");
            }
            string name = result.Dequeue();
            Console.WriteLine($"Last is {name}");
        }
    }
}
