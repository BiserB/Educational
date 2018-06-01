using System;
using System.Net;
using System.Net.Sockets;

namespace AsyncWebServer
{
    public class SocketServer
    {
        private static TcpListener serverSocket;

        public static void StartServer()
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");

            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 8081);

            serverSocket = new TcpListener(ipEndPoint);

            serverSocket.Start();

            Console.WriteLine("Asynchonous server socket is listening at: " + ipEndPoint.Address.ToString());

            WaitForClients();
        }

        private static void WaitForClients()
        {
            serverSocket.BeginAcceptTcpClient(new AsyncCallback(OnClientConnected), null);
        }

        private static void OnClientConnected(IAsyncResult asyncResult)
        {
            try
            {
                TcpClient clientSocket = serverSocket.EndAcceptTcpClient(asyncResult);

                if (clientSocket != null)
                {
                    Console.WriteLine("Received connection request from: " + clientSocket.Client.RemoteEndPoint.ToString());
                }

                HandleClientRequest(clientSocket);
            }
            catch
            {
                throw;
            }

            WaitForClients();
        }

        private static void HandleClientRequest(TcpClient clientSocket)
        {
            
        }

    }
}