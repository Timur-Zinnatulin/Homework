using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    /// <summary>
    /// FTP server class
    /// </summary>
    public class FtpServer
    {
        private volatile int currentConnections;

        private CancellationTokenSource cancellationToken = new CancellationTokenSource();

        public FtpServer(int maxConnections, int port)
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

        public void Shutdown()
            => this.cancellationToken.Cancel();

        /// <summary>
        /// Starts up the server
        /// </summary>
        public async Task Start()
        {
            var listener = new TcpListener(IPAddress.Any, this.Port);
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

                IPAddress clientIP;
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
        private async void SupplyClient(object clientObject)
        {
            using (var client = (TcpClient)clientObject)
            {
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
                                    break;
                                }

                            case '2':
                                {
                                    Console.WriteLine($"Client {clientIP} requested file.");
                                    this.WriteFileBytes(path, outputStream);
                                    break;
                                }
                        }
                    }
                }

                catch (IOException)
                {
                    this.HandleClientDisconnected();
                    Interlocked.Decrement(ref this.currentConnections);
                    return;
                }
                Interlocked.Decrement(ref this.currentConnections);

                Console.WriteLine($"Client {clientIP} disconnected.");
            }
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
                this.HandleIncorrectPath(output, "Access forbidden.");
                return;
            }
            catch (ArgumentException)
            {
                this.HandleIncorrectPath(output, "Path contains prohibited characters.");
                return;
            }
            catch (PathTooLongException)
            {
                this.HandleIncorrectPath(output, "Path is too long.");
                return;
            }

            if (!directory.Exists)
            {
                this.HandleIncorrectPath(output, "Directory does not exist.");
                return;
            }

            FileSystemInfo[] directoryContents;

            // Get info about files in directory
            try
            {
                directoryContents = directory.GetFileSystemInfos();
            }

            catch (UnauthorizedAccessException)
            {
                this.HandleIncorrectPath(output, "Access forbidden.");
                return;
            }

            // Write length of output
            try
            {
                output.Write($"{directoryContents.Length}");
            }

            catch (ObjectDisposedException)
            {
                this.HandleClientDisconnected();
                return;
            }

            foreach (var entity in directoryContents)
            {
                // Write about each entity (file | directory) in this directory
                try
                {
                    if (entity is DirectoryInfo)
                    {
                        output.Write($" {((DirectoryInfo)entity).Name.Replace(' ', '/')} {true.ToString()}");
                    }

                    else if (entity is FileInfo)
                    {
                        output.Write($" {((FileInfo)entity).Name.Replace(' ', '/')} {false.ToString()}");
                    }
                }

                catch (ObjectDisposedException)
                {
                    this.HandleClientDisconnected();
                    return;
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
                this.HandleClientDisconnected();
                return;
            }
        }
        
        /// <summary>
        /// Writes file information by given path
        /// </summary>
        private void WriteFileBytes(string path, StreamWriter output)
        {
            const int bufferSize = 1024 * 1024;

            var rootPath = Path.GetTempPath();
            if (path != "~")
            {
                rootPath += path;
            }

            FileInfo file;
            try
            {
                file = new FileInfo(rootPath);
            }

            catch (SecurityException)
            {
                this.HandleIncorrectPath(output, "Access forbidden.");
                return;
            }
            catch (UnauthorizedAccessException)
            {
                this.HandleIncorrectPath(output, "Access denied.");
                return;
            }
            catch (ArgumentException)
            {
                this.HandleIncorrectPath(output, "Path contains prohibited characters.");
                return;
            }
            catch (PathTooLongException)
            {
                this.HandleIncorrectPath(output, "Path is too long.");
                return;
            }

            if (!file.Exists)
            {
                this.HandleIncorrectPath(output, "File does not exist.");
                return;
            }

            FileStream fileStream;
            try
            {
                fileStream = file.OpenRead();
            }

            catch (IOException)
            {
                this.HandleIncorrectPath(output, "File is already open.");
                return;
            }
            catch (UnauthorizedAccessException)
            {
                this.HandleIncorrectPath(output, "Path leads to directory.");
                return;
            }

            try
            {
                output.Write($"{file.Length} ");
                output.Flush();
            }
            catch (ObjectDisposedException)
            {
                this.HandleClientDisconnected();
                return;
            }

            try
            {
                fileStream.CopyTo(output.BaseStream, bufferSize);
            }
            catch (ObjectDisposedException)
            {
                this.HandleClientDisconnected();
                return;
            }
            catch (IOException)
            {
                this.HandleClientDisconnected();
                return;
            }

            try
            {
                output.Flush();
            }
            catch (ObjectDisposedException)
            {
                this.HandleClientDisconnected();
            }
        }

        /// <summary>
        /// Handles client disconnection
        /// </summary>
        private void HandleClientDisconnected()
            => Console.WriteLine("Client has closed socket, skipping.");

        /// <summary>
        /// Handles incorrect requested path
        /// </summary>
        private void HandleIncorrectPath(StreamWriter output, string message = "")
        {
            Console.WriteLine("Client requested incorrect path: " + message);

            try
            {
                output.WriteLine("-1");
                output.Flush();
            }
            catch (ObjectDisposedException)
            {
                this.HandleClientDisconnected();
                return;
            }
        }
    }
}