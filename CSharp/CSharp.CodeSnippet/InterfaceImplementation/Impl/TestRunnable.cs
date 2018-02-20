using InterfaceImplementation.Abstracts;
using System;

namespace InterfaceImplementation.Impl
{
    public class TestRunnable : ITestRunnable
    {
        public void RunIMappable(IMappable mappable, string firstName)
        {
            Console.Out.WriteLine(mappable.resolveName(firstName));
        }

        public void RunILinkMappable(ILinkMappable linkMappable, string firstName)
        {
            Console.Out.WriteLine(linkMappable.resolveName(firstName));
        }

        public void Run(TestMappable mappable, string firstName)
        {
            Console.Out.WriteLine(mappable.resolveName(firstName));
        }
    }
}
