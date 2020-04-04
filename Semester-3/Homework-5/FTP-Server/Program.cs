using System;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new FtpServer(10, 8888);
            server.Start();
            Console.ReadLine();
            server.Shutdown();
        }
    }
}
