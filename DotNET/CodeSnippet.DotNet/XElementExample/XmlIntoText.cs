using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XElementExample
{
    public class XmlIntoText
    {
        public string GetXmlText()
        {
            XElement root = new XElement("Record",
                                         new XAttribute("Epoc", 2000),
                                         new XElement("Name",
                                                      new XElement("First", "Mike"),
                                                      new XElement("Second")),
                                         new XElement("Address"));

            // Easy to convert XElement into XDocument
            XDocument xDoc = new XDocument(root);

            return root.ToString(SaveOptions.DisableFormatting);
        }
    }
}
