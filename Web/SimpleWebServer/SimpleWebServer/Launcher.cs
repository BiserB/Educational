using System;
using System.Net;
using System.Text;
using System.Threading;

namespace SimpleWebServer
{
    public class Launcher
    {
        static void Main()
        {
            Console.WriteLine("Running async server.");
            new AsyncServer();
        }
    }
   
    public class AsyncServer
    {
        public AsyncServer()
        {
            var listener = new HttpListener();

            listener.Prefixes.Add("http://localhost:8081/");
            listener.Prefixes.Add("http://127.0.0.1:8081/test/");

            listener.Start();

            while (true)
            {
                try
                {
                    var context = listener.GetContext();
                    ThreadPool.QueueUserWorkItem(o => HandleRequest(context));
                }
                catch (Exception)
                {
                    // Ignored for this example
                }
            }
        }

        private void HandleRequest(object state)
        {
            try
            {
                var context = (HttpListenerContext)state;

                context.Response.StatusCode = 200;
                context.Response.SendChunked = true;

                int totalTime = 0;

                while (true)
                {
                    if (totalTime % 3000 == 0)
                    {
                        var bytes = Encoding.UTF8.GetBytes(new string('3', 10) + "\n");
                        context.Response.OutputStream.Write(bytes, 0, bytes.Length);
                    }

                    if (totalTime % 5000 == 0)
                    {
                        var bytes = Encoding.UTF8.GetBytes(new string('5', 10) + "\n");
                        context.Response.OutputStream.Write(bytes, 0, bytes.Length);
                    }

                    Thread.Sleep(1000);
                    totalTime += 1000;
                }
            }
            catch (Exception)
            {
                // Client disconnected or some other error - ignored for this example
            }
        }
    }
}