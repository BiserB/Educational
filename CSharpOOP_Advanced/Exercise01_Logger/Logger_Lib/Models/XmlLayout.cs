using Logger_Lib.Models.Contracts;
using System;
using System.Globalization;

namespace Logger_Lib.Models
{
    public class XmlLayout : ILayout
    {
        //<log>
        //  <date>3/31/2015 5:33:07 PM</date>
        //  <level>ERROR</level>
        //  <message>Error parsing request</message>
        //</log>
       
        private  string PATTERN =      "<log>" + Environment.NewLine +
                                       "\t<date>{0}</date>" + Environment.NewLine +
                                       "\t<level>{1}</level>" + Environment.NewLine +
                                       "\t<message>{2}</message>" + Environment.NewLine +
                                       "</log>";

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