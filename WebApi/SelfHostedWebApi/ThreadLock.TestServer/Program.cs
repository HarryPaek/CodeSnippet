using ePlatform.Common.DI;
using System;
using ThreadLock.OwinServer.Abstracts;

namespace ThreadLock.TestServer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var server = IoC.Resolve<IWebApiServer>())
            {
                server.Start();

                Console.WriteLine(" Please press <ENTER> to QUIT the Service...");
                Console.ReadLine();
            }
        }
    }
}
