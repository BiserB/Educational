using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Read a text, extract its words, find all short words 
// (less than 5 characters) and print them alphabetically, in lowercase.

namespace ShorWordsSorted
{
    class Program
    {
        static void Main(string[] args)
        {            
            string[] delimiter = new string[] {".", ",", ":", ";", "(", ")", "[", "]", "\"", "'", "\\", "/", "!", "?", " " };
            string[] input = Console.ReadLine().ToLower().Split(delimiter,StringSplitOptions.RemoveEmptyEntries);
            var result = input.Where(p => p.Length < 5).Distinct().ToList();
            Console.WriteLine(string.Join(", ", result.OrderBy(word => word)));
        }
    }
}
