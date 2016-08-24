using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XElementExample
{
    public class TextIntoXml
    {
        public XDocument GetXmlDocument(string xmlText)
        {
            XDocument xmlDocument = XDocument.Parse(xmlText);

            return xmlDocument;
        }
    }
}
