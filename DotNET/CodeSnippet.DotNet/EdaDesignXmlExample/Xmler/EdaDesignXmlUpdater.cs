using EdaDesignXmlExample.Abstracts;
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace EdaDesignXmlExample.Xmler
{
    public class EdaDesignXmlUpdater : IXmler
    {
        public void Execute(string xmlFilePath)
        {
            if (string.IsNullOrWhiteSpace(xmlFilePath))
                throw new ArgumentNullException("xmlFilePath");

            if (!File.Exists(xmlFilePath))
                throw new ArgumentException(string.Format("지정된 XML 파일 [{0}]이(가) 존재하지 않습니다.", xmlFilePath), "xmlFilePath");

            string edaDesignXmlNameSpace = "http://www.plmxml.org/Schemas/tceda";

            XDocument xdoc = XDocument.Load(xmlFilePath);
            XElement xCca = xdoc.Root.Element(XName.Get("CCA", edaDesignXmlNameSpace));

            if (xCca == null)
                return;

            string xName = xCca.Attribute("name") == null ? "NULL" : xCca.Attribute("name").Value;
            string xItemId = xCca.Attribute("itemId") == null ? "NULL" : xCca.Attribute("itemId").Value;
            string xRevId = xCca.Attribute("revId") == null ? "NULL" : xCca.Attribute("revId").Value;

            Console.WriteLine("xName=[{0}], xItemId=[{1}], xRevId=[{2}]", xName, xItemId, xRevId);

            XElement xElementOldRev = xCca.Descendants(XName.Get("attr", edaDesignXmlNameSpace))
                                          .FirstOrDefault(xe => xe.Attributes().Any(xa => xa.Value.Equals("RevisionNo", StringComparison.OrdinalIgnoreCase)));

            Console.WriteLine("xElementOldRev = [{0}]", xElementOldRev == null ? "NULL" : xElementOldRev.ToString());

            if (xElementOldRev == null)
                return;

            string zName = xElementOldRev.Attribute("name") == null ? "NULL" : xElementOldRev.Attribute("name").Value;
            string zValue = xElementOldRev.Attribute("value") == null ? "NULL" : xElementOldRev.Attribute("value").Value;

            Console.WriteLine("zName=[{0}], zValue=[{1}]", zName, zValue);
        }
    }
}
