using SimpleMVC.Server.Contracts;
using SimpleMVC.Server.Handlers;
using SimpleMVC.Server.HTTP;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleMVC.Server
{
    public class ConnectionHandler
    {
        private readonly Socket client;

        private readonly IServerRouteConfig serverRouteConfig;

        public ConnectionHandler(Socket client, IServerRouteConfig serverRouteConfig)
        {
            this.client = client;
            this.serverRouteConfig = serverRouteConfig;
        }

        public async Task ProcessRequestAsync()
        {            
            string requestString = await ReadRequest();

            if (requestString != null)
            {
                Console.WriteLine("--Request-----");
                Console.WriteLine(requestString);

                var httpRequest = new HttpRequest(requestString);

                Console.WriteLine();
                Console.WriteLine("Sessions: " + SessionStore.GetSesions());

                var httpResponse = new HttpHandler(this.serverRouteConfig).Handle(httpRequest);

                var responseBytes = Encoding.UTF8.GetBytes(httpResponse.ToString());

                var byteSegment = new ArraySegment<byte>(responseBytes);

                await this.client.SendAsync(byteSegment, SocketFlags.None);

                
                

                Console.WriteLine("--Response-----");
                Console.WriteLine(httpResponse);
                Console.WriteLine();
            }

            this.client.Shutdown(SocketShutdown.Both);
        }        

        private async Task<string> ReadRequest()
        {
            string request = string.Empty;
            
            byte[] buffer = new byte[1024];

            int numBytesRead = 0;

            while ((numBytesRead = await this.client.ReceiveAsync(buffer, SocketFlags.None)) > 0)
            {
                request += Encoding.UTF8.GetString(buffer, 0, numBytesRead);
                if (numBytesRead < 1024)
                {
                    break;
                }
            }

            if (request.Length == 0)
            {
                return null;
            }

            return request;
        }
    }
}