using ePlatform.Common.DI;
using ePlatform.WebApi.Abstracts;
using System;

namespace ThreadLock.TestServer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var server = IoC.Resolve<IWebApiServer>())
            {
                server.Start();

                Console.WriteLine("");
                Console.WriteLine(" Please press <ENTER> to QUIT the Service...");

                Console.ReadLine();
            }
        }
    }
}
