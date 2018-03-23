using Logger_Lib.Models.Enums;
using System;

namespace Logger_Lib.Models.Contracts
{
    public interface IMessage
    {
        DateTime Date_Time { get; }

        MessageLevel Level { get; }

        string Content { get; }
    }
}