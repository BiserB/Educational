using Logger_Lib.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Logger_Lib.Models.Enums;

namespace Logger_Lib.Models
{
    public class FileAppender : IAppender
    {
        private double counter;

        private ILogFile logFile;

        public FileAppender(ILayout layout, MessageLevel level, ILogFile file)
        {
            Layout = layout;
            Level = level;
            logFile = file;
            counter = 0;            
        }        

        public ILayout Layout { get; }

        public MessageLevel Level { get; }

        public void AppendMessage(IMessage message)
        {
            string formated = Layout.LayoutFormat(message);
            logFile.Write(formated);
            counter++;
        }

        public override string ToString()
        {
            string aType = GetType().Name;
            string lType = Layout.GetType().Name;
            string level = Level.ToString();
            string info = $"Appender type: {aType}, Layout type: {lType}, " +
                          $"Report level: {level}, Messages appended: {counter}," +
                          $"File size: {logFile.Size}"; 
            return info;
        }
    }
}
