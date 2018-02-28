using System;
using System.IO;

namespace Task02
{
    class Program
    {
        static void Main()
        {
            StreamReader reader = new StreamReader("text.txt");
            StreamWriter writer = new StreamWriter("output.txt");
            using (reader)
            {  
                using (writer)
                {
                    string line = reader.ReadLine();
                    int cnt = 1;
                    while (line != null)
                    {
                        writer.WriteLine($"Line {cnt}: " + line);
                        line = reader.ReadLine();
                        cnt++;
                    }                    
                }   
            }

        }
    }
}
