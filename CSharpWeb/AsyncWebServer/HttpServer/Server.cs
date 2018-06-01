using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HttpServer
{
    public static class Server
    {              
        public static int maxSimultaneousConnections = 20;
        private static Semaphore sem = new Semaphore(maxSimultaneousConnections, maxSimultaneousConnections);
        
        private static HttpListener InitializeListener()
        {
            HttpListener listener = new HttpListener();

            listener.Prefixes.Add("http://127.0.0.1:8081/");

            Console.WriteLine("Listening on IP 127.0.0.1:8081");
            
            return listener;
        }

        private static void StartListener(HttpListener listener)
        {
            listener.Start();
            Task.Run(() => RunServer(listener));
        }

        public static void Start()
        {
            HttpListener listener = InitializeListener();
            StartListener(listener);
        }

        private static void RunServer(HttpListener listener)
        {
            while (true)
            {
                sem.WaitOne();
                StartConnectionListener(listener);
            }
        }

        private static async void StartConnectionListener(HttpListener listener)
        {
            // Wait for a connection. Return to caller while we wait.
            HttpListenerContext context = await listener.GetContextAsync();

            // Release the semaphore so that another listener can be immediately started up.
            sem.Release();

            // We have a connection, do something...
            string response = "Hello Browser!";
            byte[] encoded = Encoding.UTF8.GetBytes(response);
            context.Response.ContentLength64 = encoded.Length;
            await Task.Delay(5000);
            context.Response.OutputStream.Write(encoded, 0, encoded.Length);
            context.Response.OutputStream.Close();
        }        
    }
}
