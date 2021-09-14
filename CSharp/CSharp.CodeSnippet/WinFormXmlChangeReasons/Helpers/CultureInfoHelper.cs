using log4net;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;

namespace WinFormXmlChangeReasons.Helpers
{
    public static class CultureInfoHelper
    {
        private static ILog _logger = LogManager.GetLogger(typeof(CultureInfoHelper));

        public static IEnumerable<CultureInfo> GetAvailableCultures(Type resourceSource)
        {
            if (_logger.IsDebugEnabled)
                _logger.DebugFormat("resourceSource=[{0}]", resourceSource == null ? "<NULL>" : resourceSource.ToString());

            if(resourceSource == null)
                throw new ArgumentNullException(nameof(resourceSource));

            List<CultureInfo> result = new List<CultureInfo>();

            ResourceManager rm = new ResourceManager(resourceSource);

            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            foreach (var cultureInfo in cultures.Select((culture, index) => new { Index = index, Culture = culture}))
            {
                try
                {
                    _logger.DebugFormat("cultures[{0}]=[{1}]", cultureInfo.Index, cultureInfo.Culture);

                    if (cultureInfo.Culture.Equals(CultureInfo.InvariantCulture)) continue; //do not use "==", won't work

                    ResourceSet rs = rm.GetResourceSet(cultureInfo.Culture, true, false);

                    if(_logger.IsDebugEnabled) {
                        string isSupported = (rs == null) ? "is not supported" : "is supported";

                        _logger.DebugFormat("'{0}'[{1}] {2}", cultureInfo.Culture, cultureInfo.Culture.DisplayName, isSupported);
                    }

                    if (rs != null)
                        result.Add(cultureInfo.Culture);
                }
                catch (CultureNotFoundException cnfex)
                {
                    if (_logger.IsWarnEnabled)
                        _logger.Warn(cnfex.Message, cnfex);

                    if (_logger.IsDebugEnabled) {
                        _logger.DebugFormat("'{0}'[{1}] {2}", cultureInfo.Culture, cultureInfo.Culture.DisplayName, "is not available on the machine or is an invalid culture identifier.");
                    }
                }
                catch(Exception ex)
                {
                    if (_logger.IsWarnEnabled)
                        _logger.Warn(ex.Message, ex);
                }
            }

            return result;
        }
    }
}
