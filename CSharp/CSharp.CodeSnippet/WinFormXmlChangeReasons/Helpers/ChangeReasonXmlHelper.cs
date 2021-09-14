using log4net;
using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using WinFormXmlChangeReasons.Models;

namespace WinFormXmlChangeReasons.Helpers
{
    public static class ChangeReasonXmlHelper
    {
        private static ILog _logger = LogManager.GetLogger(typeof(ChangeReasonXmlHelper));

        public static ChangeReasonList FromXml(string xmlFullPath)
        {
            #region Parameter Validation

            if (_logger.IsDebugEnabled)
                _logger.DebugFormat("FromXml(), xmlFullPath=[{0}], xmlFullPath.Exists=[{1}]",
                                     string.IsNullOrWhiteSpace(xmlFullPath) ? "NULL" : xmlFullPath,
                                     string.IsNullOrWhiteSpace(xmlFullPath) ? "NULL" : File.Exists(xmlFullPath).ToString());

            if (string.IsNullOrWhiteSpace(xmlFullPath))
                throw new ArgumentNullException("xmlFullPath");

            #endregion

            try
            {
                if (!File.Exists(xmlFullPath))
                    throw new FileNotFoundException("변경 사유를 정의한 XML 파일을 찾을 수 없습니다.", Path.GetFileNameWithoutExtension(xmlFullPath));

                using (var fileStream = new FileStream(xmlFullPath, FileMode.Open))
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    return new XmlSerializer(typeof(ChangeReasonList)).Deserialize(streamReader) as ChangeReasonList;
                }
            }
            catch (Exception ex)
            {
                if (_logger.IsWarnEnabled)
                    _logger.Warn(ex.Message, ex);

                return new ChangeReasonList();
            }
        }
    }
}
