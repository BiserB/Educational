using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Task06
{
    class Program
    {
        private static List<string> files = new List<string>();
        static void Main()
        {

            string sourceName = "sliceMe.mp4";
            string destDir = Directory.GetCurrentDirectory();

            Console.Write("parts = ");
            int parts = int.Parse(Console.ReadLine());

            ZipSlice(sourceName, destDir, parts);

            ZipAssemble(files, destDir);

        }

        public static void ZipSlice(string sourceName, string destDir, int parts)
        {
            FileStream sourceStream = new FileStream(sourceName, FileMode.Open);

            using (sourceStream)
            {
                int partSize = (int)(sourceStream.Length / parts);
                byte[] buffer = new byte[partSize];

                for (int i = 0; i < parts; i++)
                {
                    string destPath = Path.Combine(destDir + @"\Part" + i + ".gz");
                    FileStream destStream = new FileStream(destPath, FileMode.Create, FileAccess.Write);
                    using (destStream)
                    {
                        int part = sourceStream.Read(buffer, 0, partSize);

                        GZipStream zipStream = new GZipStream(destStream, CompressionMode.Compress);
                        using (zipStream)
                        {
                            zipStream.Write(buffer, 0, part);
                        }

                        files.Add(destPath);
                    }
                }
            }
        }

        private static void ZipAssemble(List<string> files, string destDir)
        {
            string destPath = Path.Combine(destDir + @"\result.mp4");
            FileStream destStream = new FileStream(destPath, FileMode.Append);
            using (destStream)
            {
                foreach (string filePath in files)
                {
                    FileStream sourceStream = new FileStream(filePath, FileMode.Open);
                    using (sourceStream)
                    {                        
                        GZipStream unzipStream = new GZipStream(sourceStream, CompressionMode.Decompress);
                        using (unzipStream)
                        {
                            byte[] buffer = new byte[4096];

                            while (true)
                            {
                                int readedBytes = unzipStream.Read(buffer, 0, buffer.Length);
                                if (readedBytes == 0)
                                {
                                    break;
                                }
                                
                                destStream.Write(buffer, 0, readedBytes);
                            }

                        }
                        
                    }
                }
            }
        }        
    }
}
