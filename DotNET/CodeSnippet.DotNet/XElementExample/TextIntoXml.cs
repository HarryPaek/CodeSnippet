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
            StringBuilder sampleXmlBuider = new StringBuilder("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sampleXmlBuider.Append("<activity>");
            sampleXmlBuider.Append("<input>");
            sampleXmlBuider.Append("<inputwork name=\"Design Review.xls\" key=\"27\" table=\"DOCUMENT_TEMPLATE\" title=\"Design review\" />");
            sampleXmlBuider.Append("<inputwork name=\"Design FMEA.xls\" key=\"29\" table=\"DOCUMENT_TEMPLATE\" title=\"Design FMEA\" />");
            sampleXmlBuider.Append("</input>");
            sampleXmlBuider.Append("<work>");
            sampleXmlBuider.Append("<currentwork name=\"BOMLIST.xlsx\" key=\"538\" table=\"DOCUMENT\" title=\"BOMLIST\" />");
            sampleXmlBuider.Append("<currentwork name=\"PDM 서버.txt\" key=\"532\" table=\"DOCUMENT\" title=\"테스트1111\" />");
            sampleXmlBuider.Append("<currentwork name=\"Test Report.xls\" key=\"26\" table=\"DOCUMENT_TEMPLATE\" title=\"Test Report\" />");
            sampleXmlBuider.Append("<currentwork name=\"BOM of Cup.txt\" key=\"31\" table=\"DOCUMENT_TEMPLATE\" title=\"Kim 0329\" />");
            sampleXmlBuider.Append("</work>");
            sampleXmlBuider.Append("<user>");
            sampleXmlBuider.Append("<currentuser name=\"[TestUser02]Test User 02\" key=\"TestUser02\" table=\"USER\" title=\"[TestUser02]Test User 02\"/>");
            sampleXmlBuider.Append("<currentuser name=\"[TestUser01]Test User 01\" key=\"TestUser01\" table=\"USER\" title=\"[TestUser01]Test User 01\"/>");
            sampleXmlBuider.Append("</user>");
            sampleXmlBuider.Append("<map />");
            sampleXmlBuider.Append("</activity>");
            XDocument xmlDocument = XDocument.Parse(sampleXmlBuider.ToString());

            return xmlDocument;
        }
    }
}
