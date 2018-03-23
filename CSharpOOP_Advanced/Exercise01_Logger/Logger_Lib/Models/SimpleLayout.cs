using Logger_Lib.Models.Contracts;
using System;
using System.Globalization;

namespace Logger_Lib.Models
{
    public class SimpleLayout : ILayout
    {
        // <date-time> - <report level> - <message>

        private const string PATTERN = "{0} - {1} - {2}";

        private const string DATE_FORMAT = "M/d/yyyy h:mm:ss tt";

        private IFormatProvider provider = CultureInfo.InvariantCulture;

        public string LayoutFormat(IMessage message)
        {
            string dateString = message.Date_Time.ToString(DATE_FORMAT, provider);
            string result = string.Format(PATTERN, dateString, message.Level, message.Content);
            return result;
        }
    }
}