using Logger_Lib.Models.Contracts;
using Logger_Lib.Models.Enums;
using System;
using System.Globalization;

namespace Logger_Lib.Models.Factories
{
    public class MessageFactory
    {
        private const string DATE_FORMAT = "M/d/yyyy h:mm:ss tt";
        private IFormatProvider provider = CultureInfo.InvariantCulture;

        public IMessage Create(string dateTime, string level, string content)
        {
            DateTime dt = DateTime.ParseExact(dateTime, DATE_FORMAT, provider);

            MessageLevel msgLevel = MessageLevel.INFO;

            Enum.TryParse(level, out msgLevel);

            return new Message(dt, msgLevel, content);
        }
    }
}