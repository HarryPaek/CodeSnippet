using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using XElementExample.Helper;

namespace XElementExample
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlIntoText texter = new XmlIntoText();

            Console.WriteLine("Xml Text = [{0}]", texter.GetXmlText());

            TextIntoXml xmler = new TextIntoXml();
            var xmlDocuemnt = xmler.GetXmlDocument(XmlTextGenerator.GetStandardXmlText());

            Console.WriteLine("xDoc Text = [{0}]", xmlDocuemnt.ToString(SaveOptions.None));

            XmlDataObject dataObject = new XmlDataObject();

            dataObject.GenerateDataObject(XmlTextGenerator.GetStandardXmlText());
            dataObject.PrintDataObject();
            Console.WriteLine("GetStandardXmlText() Xml Text = [{0}]", dataObject.GetXml(SaveOptions.None));

            dataObject.GenerateDataObject(XmlTextGenerator.GetXmlWithOutputText());
            dataObject.PrintDataObject();
            Console.WriteLine("GetXmlWithOutputText() Xml Text = [{0}]", dataObject.GetXml(SaveOptions.None));

            dataObject.GenerateDataObject(XmlTextGenerator.GetXmlWithoutDataText());
            dataObject.PrintDataObject();
            Console.WriteLine("GetXmlWithoutDataText() Xml Text = [{0}]", dataObject.GetXml(SaveOptions.None));

            dataObject.GenerateDataObject(XmlTextGenerator.GetSimpleXmlText());
            dataObject.PrintDataObject();
            Console.WriteLine("GetSimpleXmlText() Xml Text = [{0}]", dataObject.GetXml(SaveOptions.None));

            dataObject.GenerateDataObject(XmlTextGenerator.GetBrokenXmlText());
            dataObject.PrintDataObject();
            Console.WriteLine("GetBrokenXmlText() Xml Text = [{0}]", dataObject.GetXml(SaveOptions.None));

            dataObject.GenerateDataObject(XmlTextGenerator.GetEmptyXmlText());
            dataObject.PrintDataObject();
            Console.WriteLine("GetEmptyXmlText() Xml Text = [{0}]", dataObject.GetXml(SaveOptions.None));

            dataObject.GenerateDataObject(XmlTextGenerator.GetNullXmlText());
            dataObject.PrintDataObject();
            Console.WriteLine("GetNullXmlText() Xml Text = [{0}]", dataObject.GetXml(SaveOptions.None));

            Console.ReadLine();
        }
    }
}
