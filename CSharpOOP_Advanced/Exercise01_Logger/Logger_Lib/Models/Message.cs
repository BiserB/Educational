using Logger_Lib.Models.Contracts;
using Logger_Lib.Models.Enums;
using System;

namespace Logger_Lib.Models
{
    public class Message : IMessage
    {
        public Message(DateTime dateTime, MessageLevel level, string content)
        {
            Date_Time = dateTime;
            Level = level;
            Content = content;
        }

        public DateTime Date_Time { get; }

        public MessageLevel Level { get; }

        public string Content { get; }
    }
}