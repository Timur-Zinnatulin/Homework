using System;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;

namespace Test_1
{
    public class Client
    {
        public static async Task Launch(IPAddress ip, int port)
        {
            var listener = new TcpListener(ip, port);
            listener.Start();
            Console.WriteLine($"Listening on port {port}...");
            while (true)
            {
                var server = listener.AcceptTcpClientAsync();
                Writer(server.GetStream());
                Reader(server.GetStream());
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
