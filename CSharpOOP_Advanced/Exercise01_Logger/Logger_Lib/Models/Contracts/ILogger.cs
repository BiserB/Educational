using System.Collections.Generic;

namespace Logger_Lib.Models.Contracts
{
    public interface ILogger
    {
        ICollection<IAppender> Appenders { get; }

        void Log(IMessage msg);
    }
}