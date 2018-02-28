using System;
using System.IO;

namespace Task01
{
    class Program
    {
        static void Main()
        {
            StreamReader reader = new StreamReader("text.txt");
            using (reader)
            {
                string line = reader.ReadLine();
                int cnt = 1;
                while (line != null)
                {
                    if (cnt % 2 == 0)
                    {
                        Console.WriteLine(line);
                    }                    
                    line = reader.ReadLine();
                    cnt++;
                }
            }
        }
    }
}
