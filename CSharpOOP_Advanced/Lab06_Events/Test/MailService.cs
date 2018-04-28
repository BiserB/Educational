using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class MailService
    {
        public void OnVideoEncoded(object source, VideoEventArgs args)
        {
            Console.WriteLine("Mail service: sending an email...");
        }
    }
}
