using System.Collections.Specialized;
using System.Configuration;
using ThreadLockSample.Abstracts;

namespace ThreadLockSample.Providers
{
    public class DefaultConfigurationProvider : IConfigurationProvider
    {
        private Configuration _configuration = null;

        #region Constructors

        public DefaultConfigurationProvider()
        {
        }

        #endregion

        #region IConfigurationProvider implementations

        public Configuration Configuration
        {
            get
            {
                if (_configuration == null)
                    this._configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                return this._configuration;
            }
        }

        public KeyValueConfigurationCollection Appsettings
        {
            get { return this.Configuration.AppSettings.Settings; }
        }

        public ConnectionStringSettingsCollection ConnectionStrings
        {
            get { return this.Configuration.ConnectionStrings.ConnectionStrings; }
        }

        public string GetConnectionString(string connectionName)
        {
            if (this.ConnectionStrings != null && this.ConnectionStrings[connectionName] != null)
                return this.ConnectionStrings[connectionName].ConnectionString;

            return null;
        }

        public string ConfigurationFilePath
        {
            get { return this.Configuration.FilePath; }
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
