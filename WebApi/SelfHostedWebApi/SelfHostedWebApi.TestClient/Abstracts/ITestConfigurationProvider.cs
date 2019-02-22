using SelfHostedWebApi.Common.Abstracts;

namespace SelfHostedWebApi.TestClient.Abstracts
{
    public interface ITestConfigurationProvider : IWebApiConfigurationProvider
    {
        int NumberOfTasks { get; }
        int ThreadSpeepBetweenTasks { get; }
        int NumberOfRequestsPerTask { get; }
        int SpeepBetweenWebRequests { get; }
    }
}
