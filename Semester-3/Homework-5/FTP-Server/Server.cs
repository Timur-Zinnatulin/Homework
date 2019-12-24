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

        /// <summary>
        /// Supplies the client with information on demand
        /// </summary>
        private void SupplyClient(object clientObject)
        {
            var client = (TcpClient)clientObject;

            IPAddress clientIP;
            try
            {
                clientIP = ((IPEndPoint)client.Client.RemoteEndPoint).Address;
                var inputStream = new StreamReader(client.GetStream());
                var outputStream = new StreamWriter(client.GetStream());

                var commandType = new char[1];
                await inputStream.ReadAsync(commandType, 0, 1);

                if (commandType[0] == '1' || commandType[0] == '2')
                {
                    var path = await inputStream.ReadLineAsync();

                    switch (commandType[0])
                    {
                        case '1':
                        {
                            Console.WriteLine($"Client {clientIP} requested directory contents.");
                            this.WriteDirPath(path, outputStream);
                        }

                        case '2':
                        {
                            Console.WriteLine($"Client {clientIP} requested file.");
                            this.WriteFileBytes(path, outputStream);
                        }
                    }
                }
            }

            catch (System.IO.Exception)
            {
                this.HandleClientDisconnected();
                --this.currentConnections;
                return;
            }

            client.Close();
            --this.currentConnections;

            Console.WriteLine($"Client {clientIP} disconnected.");
        }
        
        /// <summary>
        /// Writes about directory by given path
        /// </summary>
        private void WriteDirPath(string path, StreamWriter output)
        {
            var rootPath = Path.GetTempPath();
            if (path != "~")
            {
                rootPath += path; 
            }

            // Get info about directory
            DirectoryInfo directory;
            try
            {
                directory = new DirectoryInfo(rootPath);
            }

            catch (SecurityException)
            {

            }
            catch (ArgumentException)
            {

            }
            catch (PathTooLongException)
            {

            }

            if (!directory.Exists)
            {
                this.HandleIncorrectPath(output, "The path is too long.");
            }

            FileSystemInfo[] directoryContents;

            // Get info about files in directory
            try
            {
                directoryContents = directory.GetFileSystemInfos();
            }

            catch (UnauthorizedAccessException)
            {

            }

            // Write length of output
            try
            {
                output.Write($"{directoryContents.Length}");
            }

            catch (ObjectDisposedException)
            {

            }

            foreach (var entity in directoryContents)
            {
                // Write about each entity (file | directory) in this directory
                try
                {
                    if (entity is DirectoryInfo)
                    {
                        output.Write($"{((DirectotyInfo)entity).Name.Replace(' ', '/')} {true.ToString()}");
                    }

                    else if (entity is FileInfo)
                    {
                        output.Write($"{((FileInfo)entity).Name.Replace(' ', '/')} {false.ToString()}");
                    }
                }

                catch (ObjectDisposedException)
                {

                }
            }

            // Finish the message
            try
            {
                output.WriteLine();
                output.Flush();
            }

            catch (ObjectDisposedException)
            {

            }
        }

        private void Write
    }
}