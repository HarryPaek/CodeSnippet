using System;
using System.Collections.Generic;
using ThreadLockSample.Abstracts;
using ThreadLockSample.Extensions;
using ThreadLockSample.Helpers;

namespace ThreadLockSample.Providers
{
    public class ThreadLockConfigurationProvider : ICustomConfigurationProvider<string, string>
    {
        private readonly IConfigurationProvider     _configurationProvider = null;
        private readonly Dictionary<string, string> _configurations        = null; 

        public ThreadLockConfigurationProvider(IConfigurationProvider configurationProvider)
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

        #region Public Methods

        public int NumberOfTasks
        {
            get { return SafeParser.Get<int>(_configurationProvider.Appsettings["NumberOfTasks"], 100); }
        }

        public int ThreadSpeepBetweenTasks
        {
            get { return SafeParser.Get<int>(_configurationProvider.Appsettings["ThreadSpeepBetweenTasks"], 100); }
        }

        public int NumberOfRequestsPerTask
        {
            get { return SafeParser.Get<int>(_configurationProvider.Appsettings["NumberOfRequestsPerTask"], 10); }
        }

        #endregion
    }
}
