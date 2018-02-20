using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regexmon
{
    class Program
    {
        static void Main(string[] args)
        {
            string bojo = @"[A-Za-z]+-[A-Za-z]+";
            string didi = @"[^A-Za-z-]+";
            string input = Console.ReadLine();
            while (input.Length > 0)
            {
                if (Regex.IsMatch(input, didi))
                {
                    input = FindAndDelete(input, didi);
                }
                else
                {
                    break;
                }

                if (Regex.IsMatch(input, bojo))
                {
                    input = FindAndDelete(input, bojo);
                }
                else
                {
                    break;
                }
            }
        }
        public static string  FindAndDelete(string input, string pattern)
        {
            bool ok = Regex.IsMatch(input, pattern);
            if (ok)
            {
                string identical = Regex.Match(input, pattern).ToString();
                int startIndex = input.IndexOf(identical);
                int stringLength = identical.Length;
                Console.WriteLine(Regex.Match(input, pattern));
                input = input.Remove(0, startIndex + stringLength);
            }
            return input;
        }
    }
}
