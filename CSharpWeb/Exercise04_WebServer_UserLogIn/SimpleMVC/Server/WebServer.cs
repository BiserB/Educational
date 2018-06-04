using SimpleMVC.Server.Contracts;
using SimpleMVC.Server.Routing;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace SimpleMVC.Server
{
    public class WebServer
    {
        private readonly string IpAddress = "127.0.0.1";

        private readonly int port;

        private readonly IServerRouteConfig serverRouteConfig;

        private readonly TcpListener tcpListener;

        private bool isRunning;

        public WebServer(int port, IAppRouteConfig appRouteConfig)
        {
            this.port = port;
            this.tcpListener = new TcpListener(IPAddress.Parse(IpAddress), port);
            this.serverRouteConfig = new ServerRouteConfig(appRouteConfig);
        }

        public void Run()
        {
            this.tcpListener.Start();

            this.isRunning = true;

            Console.WriteLine($"Server started. Listening for tcp clients at {IpAddress}:{this.port}");

            Task.Run(async() => await ListenLoop()).Wait();             
        }

        private async Task ListenLoop()
        {
            while (this.isRunning)
            {
                Socket client = await this.tcpListener.AcceptSocketAsync();

                ConnectionHandler connectionHandler = new ConnectionHandler(client, this.serverRouteConfig);

                await connectionHandler.ProcessRequestAsync();
            }
        }
    }
}