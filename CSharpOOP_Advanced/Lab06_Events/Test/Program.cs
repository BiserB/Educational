using System;

namespace Test
{
    public class Program
    {
        static void Main()
        {            
            var video = new Video() { Title = "Video 1"};
            var videoEncoder = new VideoEncoder();
            var mailService = new MailService();
            var messageService = new MessageService();
            
            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;

            videoEncoder.Encode(video);
        }
    }    
}
