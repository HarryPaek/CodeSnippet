using ePlatform.WebApi.Abstracts;

namespace ThreadLock.TestClient.Abstracts
{
    public interface ITestConfigurationProvider : IWebApiConfigurationProvider
    {
        int NumberOfTasks { get; }
        int ThreadSpeepBetweenTasks { get; }
        int NumberOfRequestsPerTask { get; }
        int SpeepBetweenWebRequests { get; }
    }
}
