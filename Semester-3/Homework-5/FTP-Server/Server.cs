using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class FTP_Server
    {
        private volatile int currentConnections;

        private CancellationTokenSource cancellationToken = new CancellationTokenSource();

        public FTP_Server(int maxConnections, int port)
        {
            this.Port = port;
            this.MaxConnections = maxConnections;
        }

        /// <summary>
        /// Server port number
        /// </summary>
        /// <value>0..65535</value>
        public int Port { get; }

        /// <summary>
        /// Max amount of connections
        /// </summary>
        public int MaxConnections { get; }

        /// <summary>
        /// Current amount of established connections
        /// </summary>
        public int CurrentConnections => this.currentConnections;

        /// <summary>
        /// Starts up the server
        /// </summary>
        public async Task Start()
        {
            var listener = TcpListener(IPAddress.Any, this.Port);
            listener.Start();

            Console.WriteLine("Server started on port {0}", this.Port);

            while (!this.cancellationToken.IsCancellationRequested)
            {
                var client = await listener.AcceptTcpClientAsync();

                if (this.cancellationToken.IsCancellationRequested)
                {
                    listener.Stop();
                    client.Close();
                    this.currentConnections = 0;
                    return;
                }

                try
                {
                    clientIP = ((IPEndPoint)client.Client.RemoteEndPoint).Address;
                }

                catch (ObjectDisposedException)
                {
                    Console.WriteLine("New client has closed the socket, skipping...");
                    continue;
                }

                if (this.currentConnections == this.MaxConnections)
                {
                    client.Close();
                    Console.WriteLine($"Client {0} could not connect due to amount of connections reaching limit.", clientIP);
                }

                else
                {
                    Console.WriteLine($"Client {0} connected.", clientIP);
                    ++this.currentConnections;

                    ThreadPool.QueueUserWorkItem(SupplyClient, client);
                }
            }

            listener.Stop();
        }

        private void SupplyClient(object clientObject)
        {
            var client = (TcpClient)clientObject;

            
        }
    }
}