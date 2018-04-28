using System;
using System.Threading;

namespace Test
{
    public class VideoEncoder
    {        
        // 1. Define a delegate
        // 2. Define an event based on that delegate
        // 3. Raise the event

        public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);

        public event VideoEncodedEventHandler VideoEncoded;        

        public void Encode(Video video)
        {
            Console.Write("Encoding");
            for (int i = 0; i < 8; i++)
            {
                Thread.Sleep(500);
                Console.Write(".");
            }
            Console.WriteLine();

            OnVideoEncoded(video);
        }

        protected virtual void OnVideoEncoded(Video video)
        {
            if (this.VideoEncoded != null)
            {                
                VideoEncoded(this, new VideoEventArgs(video));
            }
            
        }
    }
}