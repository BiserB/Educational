using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task07
{
    class Program
    {        
        static void Main()
        {
            Dictionary<string, List<FileInfo>> register = new Dictionary<string, List<FileInfo>>();

            string path = Console.ReadLine();

            string[] files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                string extension = fileInfo.Extension;
                if (!register.ContainsKey(extension))
                {
                    register[extension] = new List<FileInfo>();
                }
                register[extension].Add(fileInfo);                
            }
            StreamWriter reporter = new StreamWriter("report.txt");
            using (reporter)
            {
                foreach (var pair in register.OrderByDescending(f => f.Value.Count))
                {
                    reporter.WriteLine(pair.Key);
                    foreach (var file in pair.Value.OrderBy(f => f.Name))
                    {
                        double size = file.Length / 1024d;
                        reporter.WriteLine("--{0} - {1:f3}kb", file.Name, size);
                    }

                }
            }

            
        }
    }
}
