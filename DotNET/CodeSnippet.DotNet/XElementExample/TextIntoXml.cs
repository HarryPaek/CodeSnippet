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
        public XDocument GetXmlDocument()
        {
            string sampleXml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><activity><input/><work/><user><currentuser name=\"[TestUser02]Test User 02\" key=\"TestUser02\" table=\"USER\" title=\"[TestUser02]Test User 02\"/><currentuser name=\"[TestUser01]Test User 01\" key=\"TestUser01\" table=\"USER\" title=\"[TestUser01]Test User 01\"/></user><map/></activity>";
            XDocument xmlDocument = XDocument.Parse(sampleXml);

            return xmlDocument;
        }
    }
}
