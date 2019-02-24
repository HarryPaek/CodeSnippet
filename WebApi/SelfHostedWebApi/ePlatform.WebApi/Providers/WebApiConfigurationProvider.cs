using ePlatform.Common.Abstracts;
using ePlatform.Common.Helpers;
using ePlatform.Common.Providers;
using ePlatform.WebApi.Abstracts;

namespace ePlatform.WebApi.Providers
{
    public class WebApiConfigurationProvider : DefaultCustomConfigurationProvider, IWebApiConfigurationProvider
    {
        private const string _defaultServiceAddress = "http://localhost:28080/";

        public WebApiConfigurationProvider(IConfigurationProvider configurationProvider): base(configurationProvider)
        {
        }

        #region IWebApiConfigurationProvider Implementation

        public string BaseServiceAddress
        {
            get { return SafeParser.Get(this.ConfigurationProvider.Appsettings["BaseServiceAddress"], _defaultServiceAddress); }
        }

        #endregion
    }
}
