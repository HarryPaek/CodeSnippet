using InterfaceImplementation.Abstracts;
using InterfaceImplementation.Impl;
using System;

namespace InterfaceImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName      = "Harry";
            TestMappable mappable = new TestMappable();
            ILinkMappable linkMappable = new TestMappable();
            IMappable iMappable = new TestMappable();

            TestRunnable runnable = new TestRunnable();

            Console.Out.WriteLine("\nTest RunIMappable(), RunILinkMappable() and Run() with TestMappable [{0}]", mappable);
            runnable.RunIMappable(mappable, firstName);
            runnable.RunILinkMappable(mappable, firstName);
            runnable.Run(mappable, firstName);

            Console.Out.WriteLine("\nTest RunILinkMappable() with ILinkMappable [{0}]", linkMappable);
            runnable.RunILinkMappable(linkMappable, firstName);

            Console.Out.WriteLine("\nTest RunIMappable() with IMappable [{0}]", iMappable);
            runnable.RunIMappable(iMappable, firstName);

            Console.ReadLine();
        }
    }
}
