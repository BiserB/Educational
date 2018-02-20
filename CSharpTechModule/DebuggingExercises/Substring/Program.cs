using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substring
{
    class Program
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());
            char ch = 'p';
            
            bool hasMatch = false;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ch)
                {
                        hasMatch = true;
                    
                        int endIndex = i + count + 1;
                        string matchedString = "";
                        if (endIndex >= text.Length)
                        {
                            matchedString = text.Substring(i);
                        }
                        else
                        {
                            matchedString = text.Substring(i, count + 1);
                        }
                        
                        Console.WriteLine(matchedString);
                    i += count;
                }
            }

            if (!hasMatch)
            {
                Console.WriteLine("no");
            }
        }
    }
}
