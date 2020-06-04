using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new FtpClient("localhost", 8888);
            Console.ReadLine();
            client.Dispose();
        }
    }
}
