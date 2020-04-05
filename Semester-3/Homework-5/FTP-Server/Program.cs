using System;
using System.Threading.Tasks;
namespace Server
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var server = new FtpServer(10, 8888);
            await server.Start();
            Console.ReadLine();
            server.Shutdown();
        }
    }
}
