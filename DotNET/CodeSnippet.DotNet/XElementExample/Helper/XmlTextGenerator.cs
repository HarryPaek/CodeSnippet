using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XElementExample.Helper
{
    public static class XmlTextGenerator
    {
        public static string GetStandardXmlText()
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

            return sampleXmlBuider.ToString();
        }

        public static string GetXmlWithOutputText()
        {
            StringBuilder sampleXmlBuider = new StringBuilder("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sampleXmlBuider.Append("<activity>");
            sampleXmlBuider.Append("<input>");
            sampleXmlBuider.Append("<inputwork name=\"Design Review.xls\" key=\"27\" table=\"DOCUMENT_TEMPLATE\" title=\"Design review\" />");
            sampleXmlBuider.Append("<inputwork name=\"Design FMEA.xls\" key=\"29\" table=\"DOCUMENT_TEMPLATE\" title=\"Design FMEA\" />");
            sampleXmlBuider.Append("</input>");
            sampleXmlBuider.Append("<output>");
            sampleXmlBuider.Append("<outputwork name=\"Design Review.xls\" key=\"27\" table=\"DOCUMENT_TEMPLATE\" title=\"Design review\" />");
            sampleXmlBuider.Append("<outputwork name=\"Design FMEA.xls\" key=\"29\" table=\"DOCUMENT_TEMPLATE\" title=\"Design FMEA\" />");
            sampleXmlBuider.Append("</output>");
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

            return sampleXmlBuider.ToString();
        }

        public static string GetXmlWithoutDataText()
        {
            StringBuilder sampleXmlBuider = new StringBuilder("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sampleXmlBuider.Append("<activity>");
            sampleXmlBuider.Append("<input>");
            sampleXmlBuider.Append("</input>");
            sampleXmlBuider.Append("<work>");
            sampleXmlBuider.Append("</work>");
            sampleXmlBuider.Append("<user>");
            sampleXmlBuider.Append("</user>");
            sampleXmlBuider.Append("<map />");
            sampleXmlBuider.Append("</activity>");

            return sampleXmlBuider.ToString();
        }

        public static string GetSimpleXmlText()
        {
            StringBuilder sampleXmlBuider = new StringBuilder("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sampleXmlBuider.Append("<activity>");
            sampleXmlBuider.Append("</activity>");

            return sampleXmlBuider.ToString();
        }

        public static string GetBrokenXmlText()
        {
            StringBuilder sampleXmlBuider = new StringBuilder("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sampleXmlBuider.Append("<activity>");

            return sampleXmlBuider.ToString();
        }

        public static string GetEmptyXmlText()
        {
            return string.Empty;
        }

        public static string GetNullXmlText()
        {
            return null;
        }
    }
}
