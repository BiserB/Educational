using System;
using System.Linq;

namespace task07
{
    class Program
    {
        static void Main()
        {
            int length = int.Parse(Console.ReadLine());
            string[] words = Console.ReadLine().Split();
            Predicate<string> shorter = word => word.Length <= length;
            words.Where(w => shorter(w)).ToList().ForEach(w => Console.WriteLine(w));
        }
    }
}
