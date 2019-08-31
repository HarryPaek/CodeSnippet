using EdaDesignXmlExample.Abstracts;
using EdaDesignXmlExample.Xmler;
using System;

namespace EdaDesignXmlExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string xmlfilePathOpen = ".\\SampleData\\01.edaDesign_Open.xml";
            string xmlfilePathNewRevision = ".\\SampleData\\02.edaDesign_Save_NewRevision.xml";
            string xmlfilePathUpdate = ".\\SampleData\\04.edaDesign_Revise.xml";

            IXmler reader  = new EdaDesignXmlReader();
            IXmler updater = new EdaDesignXmlUpdater();

            reader.Execute(xmlfilePathOpen);
            Console.WriteLine();
            Console.WriteLine();

            updater.Execute(xmlfilePathUpdate);
            Console.WriteLine();
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
