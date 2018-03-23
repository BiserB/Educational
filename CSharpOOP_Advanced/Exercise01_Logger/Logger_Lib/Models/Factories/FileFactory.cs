using Logger_Lib.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger_Lib.Models.Factories
{
    public class FileFactory
    {
        public ILogFile Create(string fileName)
        {
            return new LogFile(fileName);
        }
    }
}
