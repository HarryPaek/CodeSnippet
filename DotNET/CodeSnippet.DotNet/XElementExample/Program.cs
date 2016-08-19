using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XElementExample
{
    class Program
    {
        static void Main(string[] args)
        {
            XElement root = new XElement("Record",
                                         new XAttribute("Epoc", 2000),
                                         new XElement("Name",
                                                      new XElement("First", "Mike"),
                                                      new XElement("Second")),
                                         new XElement("Address"));

            Console.WriteLine("Xml Text = [{0}]", root.ToString(SaveOptions.DisableFormatting));

            XDocument xDoc = new XDocument(root);
            Console.WriteLine("xDoc Text = [{0}]", xDoc.ToString(SaveOptions.DisableFormatting));

            Console.ReadLine();
        }
    }
}
