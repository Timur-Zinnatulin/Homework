using System;
using System.Threading.Tasks;
using System.Net;

namespace Test_1
{
    public class Program
    {
        //Correct input looks like this: {IPAddress}:{port}
        static void Main(string[] args)
        {
            IPAddress ip = null;
            int port = 0;
            bool isClient = false;

            string input = Console.ReadLine();
            string clientIP = null;
            if (IPAddress.TryParse(input.Split(':')[0], out clientIP))
            {
                ip = IPAddress.Parse(clientIP);
                port = Convert.ToInt32(input.Split(':')[1]);
                isClient = true;
            }

            port = Convert.ToInt32(input);
            
            //Client
            if (isClient)
            {
                Client.Launch(ip, port);
            }
            
            //Server
            else
            {
                server.Launch(port);
            }
        }
    }
}