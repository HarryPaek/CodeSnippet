using ePlatform.Common.Abstracts;
using System;
using System.Collections.Generic;

namespace ePlatform.Common.Providers
{
    public class DefaultCustomConfigurationProvider : ICustomConfigurationProvider<string, string>
    {
        private readonly IConfigurationProvider _configurationProvider = null;
        private readonly Dictionary<string, string> _configurations = null;

        public DefaultCustomConfigurationProvider(IConfigurationProvider configurationProvider)
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

        #region Protected Properties

        protected IConfigurationProvider ConfigurationProvider
        {
            get { return this._configurationProvider; }
        }

        #endregion
    }
}
