using System;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    /// <summary>
    /// FTP client class
    /// </summary>
    public class FtpClient : IDisposable
    {
        private readonly string serverName;

        private readonly int serverPort;

        private TcpClient client;

        private StreamReader inputStream;

        private StreamWriter outputStream;

        /// <summary>
        /// Connects the client to server
        /// </summary>
        private void Connect()
        {
            try
            {
                this.client = new TcpClient(this.serverName, this.serverPort);
                this.inputStream = new StreamReader(this.client.GetStream());
                this.outputStream = new StreamWriter(this.client.GetStream()) { AutoFlush = true };
            }
            catch (ObjectDisposedException)
            {
                Console.WriteLine("Failed to connect to server.");
                throw;
            }
        }

        public void Dispose()
            => Disconnect();

        /// <summary>
        /// Disconnects the client from server
        /// </summary>
        private void Disconnect()
        {
            this.outputStream.Close();
            this.inputStream.Close();
            this.client.Close();
        }

        /// <summary>
        /// Reads file size from GET reply
        /// </summary>
        private async Task<int> ReadIntFromInput()
        {
            var fileSize = string.Empty;
            while (!fileSize.EndsWith(" ", StringComparison.Ordinal))
            {
                int index = 0;
                if (!this.inputStream.EndOfStream)
                {
                    var buffer = new char[1];
                    await this.inputStream.ReadAsync(buffer, index, 1);
                    ++index;
                    fileSize += buffer[0];
                }
            }

            if (!int.TryParse(fileSize, out int resultSize))
            {
                await this.inputStream.ReadToEndAsync();
                throw new FormatException();
            }

            return resultSize;
        }

        public FtpClient(string serverName, int port)
        {
            this.serverName = serverName;
            this.serverPort = port;
        }

        /// <summary>
        /// Indicates if the client is connected to server
        /// </summary>
        public bool IsConnected => this.client.Connected;
        
        /// <summary>
        /// Sends LIST request to server
        /// </summary>
        /// <returns> List of contents metainfo </returns>
        public async Task<List<EntityInfo>> ReceiveDirContents(string path)
        {
            this.Connect();

            try
            {
                await this.outputStream.WriteLineAsync('1' + path).ConfigureAwait(false);
            }
            catch (ObjectDisposedException)
            {
                Console.WriteLine("Connection terminated.");
                this.Disconnect();
                return null;
            }

            Console.WriteLine("Request sent.");

            string[] dirContents;
            try
            {
                var dirInput = await this.inputStream.ReadLineAsync().ConfigureAwait(false);
                dirContents = dirInput.Split(' ');
            }
            catch (IOException)
            {
                Console.WriteLine("Package was corrupted.");
                this.Disconnect();
                return null;
            }

            if (dirContents.Length == 0 || (dirContents.Length != 0 && dirContents[0] == "-1"))
            {
                Console.WriteLine("Directory does not exist.");
                this.Disconnect();
                return null;
            }

            if (!int.TryParse(dirContents[0], out int fileCount))
            {
                this.Disconnect();
                return null;
            }

            Console.WriteLine("Directory info received.");

            var result = new List<EntityInfo>();
            for (int i = 0; i < fileCount; ++i)
            { 
                var fileName = dirContents[(i * 2) + 1].Replace('/', ' ');
                var isDirString = dirContents[(i * 2) + 2];

                if (!bool.TryParse(isDirString, out bool isDir))
                {
                    this.Disconnect();
                    return null;
                }

                result.Add(new EntityInfo(fileName, isDir));
            }
            /*
            var tasks = new List<Task<EntityInfo>>();
            var tokenSource = new CancellationTokenSource();
            CancellationToken ct = tokenSource.Token;
            try
            {
                for (int i = 0; i < fileCount; ++i)
                {
                    var index = i;
                    tasks.Add(Task.Run(() =>
                        {
                            var fileName = dirContents[(index * 2) + 1].Replace('/', ' ');
                            var isDirString = dirContents[(index * 2) + 2];

                            if (!bool.TryParse(isDirString, out bool isDir))
                            {
                                tokenSource.Cancel();
                            }

                            if (ct.IsCancellationRequested)
                            {
                                ct.ThrowIfCancellationRequested();
                            }

                            return new EntityInfo(fileName, isDir);
                        }, tokenSource.Token));
                }
            }
            catch (OperationCanceledException)
            {
                this.Disconnect();
                return null;
            }

            var infos = await Task.WhenAll(tasks).ConfigureAwait(false);
            var result = infos.OfType<EntityInfo>().ToList();
            */
            this.Disconnect();
            return result;
        }

        /// <summary>
        /// Sends GET request to server
        /// </summary>
        /// <param name="path"> Path to requested file </param>
        /// <param name="newFilePath"> Download result path </param>
        public async Task<bool> ReceiveFileData(string path, string newFilePath)
        {
            const int bufferSize = 1024 * 1024;

            try
            {
                this.Connect();
            }
            catch (ObjectDisposedException)
            {
                this.Disconnect();
                return false;
            }

            try
            {
                await this.outputStream.WriteLineAsync('2' + path).ConfigureAwait(false);
            }
            catch (ObjectDisposedException)
            {
                Console.WriteLine("Connection terminated.");
                this.Disconnect();
                return false;
            }

            Console.WriteLine("Request sent.");

            int firstChar;
            try
            {
                firstChar = this.inputStream.Peek();
            }
            catch (IOException)
            {
                Console.WriteLine("Package was corrupted.");
                this.Disconnect();
                return false;
            }

            if ((char)firstChar == '-')
            {
                Console.WriteLine("File does not exist.");
                this.inputStream.ReadLine();
                this.Disconnect();
                return false;
            }   

            Console.WriteLine("Answer received.");

            int bytes;
            try
            {
                bytes = await this.ReadIntFromInput();
            }
            catch (FormatException)
            {
                try
                {
                    this.inputStream.ReadLine();
                }
                catch (IOException)
                {
                }

                this.Disconnect();
                return false;
            }

            Console.WriteLine($"Downloading file, size: {bytes}B");

            FileStream resultFileStream;
            try
            {
                resultFileStream = File.Create(newFilePath);
            }
            catch (SystemException)
            {
                Console.WriteLine("Cannot create file on disk");
                this.Disconnect();
                return false;
            }

            try
            {
                await this.inputStream.BaseStream.CopyToAsync(resultFileStream, bufferSize).ConfigureAwait(false);
            }
            catch (ObjectDisposedException)
            {
                Console.WriteLine("Connection terminated.");
                this.Disconnect();
                return false;
            }
            catch (IOException)
            {
                Console.WriteLine("Package was corrupted.");
                this.Disconnect();
                return false;
            }

            Console.WriteLine("File downloaded.");

            resultFileStream.Close();
            this.Disconnect();
            return true;
        }
    }
}