using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class MessageService
    {
        public void OnVideoEncoded(object sender, VideoEventArgs args)
        {
            Console.WriteLine("Message service: Sending a message...");
        }
    }
}
