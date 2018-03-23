using Logger_Lib.Models.Contracts;
using Logger_Lib.Models.Enums;
using System;

namespace Logger_Lib.Models
{
    public class ConsoleAppender : IAppender
    {
        private double counter;

        public ConsoleAppender(ILayout layout, MessageLevel level)
        {
            Layout = layout;
            Level = level;
            counter = 0;
        }

        public ILayout Layout { get; }

        public MessageLevel Level { get; }

        public void AppendMessage(IMessage message)
        {
            string formated = Layout.LayoutFormat(message);
            Console.WriteLine(formated);
            counter++;
        }

        public override string ToString()
        {
            string aType = GetType().Name;
            string lType = Layout.GetType().Name;
            string level = Level.ToString();
            string info = $"Appender type: {aType}, Layout type: {lType}, " +
                          $"Report level: {level}, Messages appended: {counter}";                          
            return info;
        }
    }
}