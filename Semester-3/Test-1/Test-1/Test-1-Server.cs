using System;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;

namespace Test_1
{
    public class Server
    {
        public static async Task Launch(int port)
        {
            var listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            Console.WriteLine($"Listening on port {port}...");
            while (true)
            {
                var client = await listener.AcceptTcpClientAsync();
                Writer(client.GetStream());
                Reader(client.GetStream());
            }
        }

        private void Reader(NetworkStream stream)
        {
            Task.Run(async () => {
                var reader = new StreamReader(stream);
                while (true)
                {
                    var data = await reader.ReadLineAsync();
                    
                    if (data == "exit")
                    {
                        Environment.Exit(0);
                    }

                    else
                    {
                        Console.WriteLine($"Client: {data}");
                    }
                }
            });
        }

        private void Writer(NetworkStream stream)
        {
            Task.Run(async () => {
                var writer = new StreamWriter(stream) { AutoFlush = true };
                while (true)
                {
                    string message = Console.ReadLine();
                    if (message == "exit")
                    {
                        Environment.Exit(0);
                    }

                    else
                    {
                        await writer.WriteAsync(message + "\n");
                    }
                }
            });
        }
    }
}