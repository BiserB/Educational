using System;
using System.IO;

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream sourceFile = new FileStream("copyMe.png", FileMode.Open);
            FileStream destFile = new FileStream("copyResult.png", FileMode.Create);
            using (sourceFile)
            {
                using (destFile)
                {
                    var bytes = sourceFile.ReadByte();                    
                    while (bytes != -1)
                    {                        
                        destFile.WriteByte((byte)bytes);
                        bytes = sourceFile.ReadByte();
                    }                   
                    
                }
            }
        }
    }
}
