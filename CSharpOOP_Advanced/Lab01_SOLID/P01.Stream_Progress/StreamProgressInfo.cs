using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IStreamProgress stream;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(IStreamProgress stream)
        {
            this.stream = stream;
        }

        public int CalculateCurrentPercent()
        {
            return (stream.BytesSent * 100) / stream.Length;
        }
    }
}
