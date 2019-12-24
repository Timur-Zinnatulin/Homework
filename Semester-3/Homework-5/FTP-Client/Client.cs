using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

namespace Client
{
    /// <summary>
    /// FTP client class
    /// </summary>
    public class FTP_Client
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
                this.outputStream = new StreamWriter(this.client.GetStream());
            }
            catch (ObjectDisposedException)
            {
                Console.WriteLine("Failed to connect to server.");
                throw;
            }
        }

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
        private int ReadIntFromInput()
        {
            var fileSize = string.Empty;
            while (!fileSize.EndsWith(" ", StringComparison.Ordinal))
            {
                if (!this.inputStream.EndOfStream)
                {
                    var t = this.inputStream.Read();
                    fileSize += (char)t;
                }
            }

            if (!int.TryParse(fileSize, out int resultSize))
            {
                this.inputStream.ReadToEnd();
                throw new FormatException();
            }

            return resultSize;
        }

        public FTP_Client(string serverName, int port)
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
        public List<EntityInfo> ReceiveDirContents(string path)
        {
            this.Connect();

            try
            {
                this.outputStream.WriteLine("1 " + path);
                this.outputStream.Flush();
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
                dirContents = this.inputStream.ReadLine().Split(' ');
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

            this.Disconnect();
            return result;
        }

        /// <summary>
        /// Sends GET request to server
        /// </summary>
        /// <param name="path"> Path to requested file </param>
        /// <param name="newFilePath"> Download result path </param>
        public bool ReceiveFileData(string path, string newFilePath)
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
                this.outputStream.WriteLine("2 " + path);
                this.outputStream.Flush();
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
                bytes = this.ReadIntFromInput();
            }
            catch (FormatException)
            {
                try
                {
                    this.inputStream.ReadLine();
                }
                catch (IOException)
                    {}
                
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
                this.inputStream.BaseStream.CopyTo(resultFileStream, bufferSize);
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