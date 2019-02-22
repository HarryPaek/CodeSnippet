using SelfHostedWebApi.Common.DI;
using SelfHostedWebApi.TestClient.Abstracts;
using System;

namespace SelfHostedWebApi.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ITest testFactory = IoC.Resolve<ITest>("factory");
            testFactory.Run();

            Console.WriteLine("Press <Enter> to quit.");
            Console.ReadLine();
        }
    }
}
