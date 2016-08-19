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
            XmlIntoText texter = new XmlIntoText();

            Console.WriteLine("Xml Text = [{0}]", texter.GetXmlText());

            TextIntoXml xmler = new TextIntoXml();
            var xmlDocuemnt = xmler.GetXmlDocument();

            Console.WriteLine("xDoc Text = [{0}]", xmlDocuemnt.ToString());

            Console.ReadLine();
        }
    }
}
