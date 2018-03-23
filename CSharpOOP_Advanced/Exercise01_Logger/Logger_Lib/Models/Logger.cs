using Logger_Lib.Models.Contracts;
using System.Collections.Generic;

namespace Logger_Lib.Models
{
    public class Logger : ILogger
    {
        public Logger(ICollection<IAppender> appenders)
        {
            Appenders = appenders;
        }

        public ICollection<IAppender> Appenders { get; }

        public void Log(IMessage msg)
        {
            foreach (var appender in Appenders)
            {
                if (appender.Level <= msg.Level)
                {
                    appender.AppendMessage(msg);
                }
            }
        }
    }
}