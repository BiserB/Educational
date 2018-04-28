using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class VideoEventArgs : EventArgs
    {
        public VideoEventArgs(Video video)
        {
            this.Video = video;
        }

        public Video Video { get; private set; }
    }
}
