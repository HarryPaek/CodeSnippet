using ePlatform.Common.Abstracts;
using ePlatform.Common.Helpers;
using ePlatform.WebApi.Providers;
using ThreadLock.TestClient.Abstracts;

namespace ThreadLock.TestClient.Providers
{
    public class DefaultTestConfigurationProvider : WebApiConfigurationProvider, ITestConfigurationProvider
    {
        public DefaultTestConfigurationProvider(IConfigurationProvider configurationProvider) : base(configurationProvider)
        {
        }

        #region ITestConfigurationProvider Implementations

        public int NumberOfTasks
        {
            get { return SafeParser.Get<int>(this.ConfigurationProvider.Appsettings["NumberOfTasks"], 100); }
        }

        public int ThreadSpeepBetweenTasks
        {
            get { return SafeParser.Get<int>(this.ConfigurationProvider.Appsettings["ThreadSpeepBetweenTasks"], 100); }
        }

        public int NumberOfRequestsPerTask
        {
            get { return SafeParser.Get<int>(this.ConfigurationProvider.Appsettings["NumberOfRequestsPerTask"], 10); }
        }

        public int SpeepBetweenWebRequests
        {
            get { return SafeParser.Get<int>(this.ConfigurationProvider.Appsettings["SpeepBetweenWebRequests"], 100); }
        }

        #endregion
    }
}
