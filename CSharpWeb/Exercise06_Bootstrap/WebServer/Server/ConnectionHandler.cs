namespace HTTPServer.Server
{
    using Common;
    using Handlers;
    using Http;
    using Http.Contracts;
    using HTTPServer.Server.Http.Response;
    using Routing.Contracts;
    using System;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    public class ConnectionHandler
    {
        private readonly Socket client;

        private readonly IServerRouteConfig serverRouteConfig;

        public ConnectionHandler(Socket client, IServerRouteConfig serverRouteConfig)
        {           
            this.client = client;
            this.serverRouteConfig = serverRouteConfig;
        }

        public async void ProcessRequestAsync()
        {
            string request = await this.ReadRequest();

            if (string.IsNullOrEmpty(request) || string.IsNullOrWhiteSpace(request))
            {
                this.client.Shutdown(SocketShutdown.Both);
                return;
            }

            var httpContext = new HttpContext(new HttpRequest(request));

            var response = new HttpHandler(this.serverRouteConfig).Handle(httpContext);

            ArraySegment<byte> responseBytes = new ArraySegment<byte>(Encoding.ASCII.GetBytes(response.ToString()));

            await this.client.SendAsync(responseBytes, SocketFlags.None);

            if (response is FileResponse)
            {
                await this.client.SendAsync(response.Content, SocketFlags.None);
            }

            Console.WriteLine($"-----REQUEST-----");
            Console.WriteLine(request);
            Console.WriteLine($"-----RESPONSE-----");
            Console.WriteLine(response);
                        
            this.client.Shutdown(SocketShutdown.Both);
        }

        private async Task<string> ReadRequest()
        {
            var result = new StringBuilder();

            var data = new ArraySegment<byte>(new byte[1024]);

            while (true)
            {
                int numberOfBytesRead = await this.client.ReceiveAsync(data.Array, SocketFlags.None);

                if (numberOfBytesRead == 0)
                {
                    break;
                }

                var bytesAsString = Encoding.UTF8.GetString(data.Array, 0, numberOfBytesRead);

                result.Append(bytesAsString);

                if (numberOfBytesRead < 1023)
                {
                    break;
                }
            }

            if (result.Length == 0)
            {
                return null;
            }

            return result.ToString();
        }
    }
}