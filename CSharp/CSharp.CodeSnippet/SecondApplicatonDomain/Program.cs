using System;

namespace SecondApplicatonDomain
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Create application domain setup information.
            AppDomainSetup domaininfo = new AppDomainSetup();
            domaininfo.ApplicationBase = "E:\\Temp\\development\\latest";

            // Create the application domain.
            AppDomain domain = AppDomain.CreateDomain("MyDomain", null, domaininfo);

            // Write application domain information to the console.
            Console.WriteLine("Host domain: " + AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine("child domain: " + domain.FriendlyName);
            Console.WriteLine("Application base is: " + domain.SetupInformation.ApplicationBase);

            // Unload the application domain.
            AppDomain.Unload(domain);

            Console.ReadLine();

            // Write application domain information to the console.
            Console.WriteLine("Host domain: " + AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine("child domain: " + domain.FriendlyName);
            Console.WriteLine("Application base is: " + domain.SetupInformation.ApplicationBase);

            Console.ReadLine();
        }
    }
}
