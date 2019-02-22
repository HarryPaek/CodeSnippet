using SelfHostedWebApi.Common.Abstracts;
using SelfHostedWebApi.Common.Helpers;
using SelfHostedWebApi.Common.Providers;
using SelfHostedWebApi.TestClient.Abstracts;

namespace SelfHostedWebApi.TestClient.Providers
{
    public class DefaultTestConfigurationProvider : WebApiConfigurationProvider, ITestConfigurationProvider
    {
        public DefaultTestConfigurationProvider(IConfigurationProvider configurationProvider):base(configurationProvider)
        {
        }

        #region ITestConfigurationProvider Implementations

        public int NumberOfTasks
        {
            get { return SafeParser.Get<int>(this.ConfigurationProvider.Appsettings["NumberOfTasks"], 100); }
        }

        public int ThreadSpeepBetweenTasks
        {
            get { return SafeParser.Get<int>(this.ConfigurationProvider.Appsettings["ThreadSpeepBetweenTasks"], 1000); }
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
