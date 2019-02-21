using Microsoft.Owin.Hosting;
using SelfHostedWebApi.Common.Abstracts;
using SelfHostedWebApi.Common.DI;
using System;

namespace SelfHostedWebApi.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = IoC.Resolve<IWebApiConfigurationProvider>();

            Console.WriteLine(" Service is starting at {0}", configuration.BaseServiceAddress);
            Console.WriteLine(" ..... ..... .....");

            using (WebApp.Start<Startup>(configuration.BaseServiceAddress))
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine(" Service was  started at {0}", configuration.BaseServiceAddress);
                Console.WriteLine(" Please press <ENTER> to QUIT the Service...");

                Console.ReadLine();
            }
        }
    }
}
