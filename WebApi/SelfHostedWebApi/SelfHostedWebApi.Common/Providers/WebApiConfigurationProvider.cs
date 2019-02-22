using SelfHostedWebApi.Common.Abstracts;
using SelfHostedWebApi.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHostedWebApi.Common.Providers
{
    public class WebApiConfigurationProvider : IWebApiConfigurationProvider
    {
        private const string _defaultServiceAddress = "http://localhost:28080/";

        private readonly IConfigurationProvider _configurationProvider = null;
        private readonly Dictionary<string, string> _configurations = null;

        public WebApiConfigurationProvider(IConfigurationProvider configurationProvider)
        {
            if (configurationProvider == null)
                throw new ArgumentNullException("configurationProvider");

            this._configurationProvider = configurationProvider;
            this._configurations = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        }

        #region ICustomConfigurationProvider Implementations

        public IDictionary<string, string> Configurations
        {
            get { return this._configurations; }
        }

        #endregion

        #region IWebApiConfigurationProvider Implementation

        public string BaseServiceAddress
        {
            get { return SafeParser.Get(this.ConfigurationProvider.Appsettings["BaseServiceAddress"], _defaultServiceAddress); }
        }

        #endregion

        #region Protected Properties

        protected IConfigurationProvider ConfigurationProvider
        {
            get { return this._configurationProvider; }
        }

        #endregion
    }
}
