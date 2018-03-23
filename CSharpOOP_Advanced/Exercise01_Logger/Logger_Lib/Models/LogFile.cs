using Logger_Lib.Models.Contracts;
using System;
using System.IO;
using System.Text;

namespace Logger_Lib.Models
{
    public class LogFile : ILogFile
    {
        private string defaultPath = "./data/";

        public LogFile(string fileName)
        {            
            Size = 0;
            Path = defaultPath + fileName;
            CreateDirectory();
        }

        private void CreateDirectory()
        {
            Directory.CreateDirectory(defaultPath);
            File.AppendAllText(Path, "");
        }

        public string Path { get; }

        public int Size { get; private set; }

        public void Write(string message)
        {
            File.AppendAllText(Path, message + Environment.NewLine);

            int msgSize = 0;
            foreach (char ch in message)
            {
                msgSize += ch;
            }
            Size += msgSize;
        }
    }
}