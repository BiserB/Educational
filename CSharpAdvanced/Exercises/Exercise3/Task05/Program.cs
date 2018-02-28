using System;
using System.Collections.Generic;
using System.IO;

namespace Task05
{
    class Program
    {
        private static List<string> files = new List<string>();
        static void Main()
        {
            
            string sourceName = "sliceMe.mp4";            
            string destDir =  Directory.GetCurrentDirectory(); 

            Console.Write("parts = ");
            int parts = int.Parse(Console.ReadLine());

            Slice(sourceName, destDir, parts);

            Assemble(files, destDir);

        }        

        public static void Slice(string sourceName, string destDir, int parts)
        {            
            try
            {
                FileStream sourceStream = new FileStream(sourceName, FileMode.Open); 
                using (sourceStream)
                {
                    int partSize = (int)(sourceStream.Length / parts);
                    byte[] buffer = new byte[partSize];

                    for (int i = 0; i < parts; i++)
                    {
                        string destPath =  Path.Combine(destDir + @"\Part" + i + ".mp4");
                        FileStream destStream = new FileStream(destPath, FileMode.Create, FileAccess.Write);
                        using (destStream)
                        {                            
                            int part = sourceStream.Read(buffer, 0, partSize);
                            destStream.Write(buffer, 0, part);
                            files.Add(destPath);
                        }
                    }                       
                                       
                }
            }
            catch (Exception message)
            {
                Console.WriteLine(message);
            }
            
        }
        private static void Assemble(List<string> files, string destDir)
        {
            string destPath = Path.Combine(destDir + @"\result.mp4");
            FileStream destStream = new FileStream(destPath, FileMode.Create);
            
            using (destStream)
            {
                foreach (string filePath in files)
                {
                    FileStream sourceFile = new FileStream(filePath, FileMode.Open);
                    using (sourceFile)
                    {
                        byte[] buffer = new byte[4096];
                        
                        while (true)
                        {
                            int readBytes = sourceFile.Read(buffer, 0, buffer.Length);
                            
                            if (readBytes == 0)
                            {                                
                                break;
                            }
                            destStream.Write(buffer, 0, readBytes);
                        }
                    }
                }
            }
        }
    }
}
