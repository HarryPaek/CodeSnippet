using EdaDesignXmlExample.Abstracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace EdaDesignXmlExample.Xmler
{
    public class EdaDesignXmlReader : IXmler
    {
        public void Execute(string xmlFilePath)
        {
            if (string.IsNullOrWhiteSpace(xmlFilePath))
                throw new ArgumentNullException("xmlFilePath");

            if (!File.Exists(xmlFilePath))
                throw new ArgumentException(string.Format("지정된 XML 파일 [{0}]이(가) 존재하지 않습니다.", xmlFilePath), "xmlFilePath");

            XDocument xdoc = XDocument.Load(xmlFilePath);
            //XElement xe = XElement.Load(xmlFilePath);

            // <Employees> 노드 하나 리턴
            IEnumerable<XElement> elems = xdoc.Elements();

            // 복수 개의 <Employee> 노드들 리턴
            IEnumerable<XElement> ccas = xdoc.Root.Elements();
            foreach (var cca in ccas)
            {
                string name = cca.Attribute("name") == null ? "NULL" : cca.Attribute("name").Value;
                string itemId = cca.Attribute("itemId") == null ? "NULL" : cca.Attribute("itemId").Value;
                string revId = cca.Attribute("revId") == null ? "NULL" : cca.Attribute("revId").Value;

                Console.WriteLine("name=[{0}], itemId=[{1}], revId=[{2}]", name, itemId, revId);
            }

            XElement aCca = xdoc.Root.Elements().FirstOrDefault(e => e.Name.LocalName.Equals("CCA", StringComparison.OrdinalIgnoreCase));

            if (aCca != null)
            {
                string aName = aCca.Attribute("name") == null ? "NULL" : aCca.Attribute("name").Value;
                string aItemId = aCca.Attribute("itemId") == null ? "NULL" : aCca.Attribute("itemId").Value;
                string aRevId = aCca.Attribute("revId") == null ? "NULL" : aCca.Attribute("revId").Value;

                Console.WriteLine("aName=[{0}], aItemId=[{1}], aRevId=[{2}]", aName, aItemId, aRevId);
            }

            XElement bCca = xdoc.Root.Element(XName.Get("CCA"));

            if (bCca != null)
            {
                string bName = bCca.Attribute("name") == null ? "NULL" : bCca.Attribute("name").Value;
                string bItemId = bCca.Attribute("itemId") == null ? "NULL" : bCca.Attribute("itemId").Value;
                string bRevId = bCca.Attribute("revId") == null ? "NULL" : bCca.Attribute("revId").Value;

                Console.WriteLine("bName=[{0}], bItemId=[{1}], bRevId=[{2}]", bName, bItemId, bRevId);
            }

            XElement xCca = xdoc.Root.Element(XName.Get("CCA", "http://www.plmxml.org/Schemas/tceda"));

            if (xCca != null)
            {
                string xName = xCca.Attribute("name") == null ? "NULL" : xCca.Attribute("name").Value;
                string xItemId = xCca.Attribute("itemId") == null ? "NULL" : xCca.Attribute("itemId").Value;
                string xRevId = xCca.Attribute("revId") == null ? "NULL" : xCca.Attribute("revId").Value;

                Console.WriteLine("xName=[{0}], xItemId=[{1}], xRevId=[{2}]", xName, xItemId, xRevId);
            }
        }
    }
}
