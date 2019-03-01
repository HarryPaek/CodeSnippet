using ePlatform.Common.DI;
using System;
using ThreadLock.TestClient.Abstracts;

namespace ThreadLock.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ITest testFactory = IoC.Resolve<ITest>("factory"))
            {
                testFactory.Run();
            }

            Console.WriteLine("Press <Enter> to quit.");
            Console.ReadLine();
        }
    }
}
