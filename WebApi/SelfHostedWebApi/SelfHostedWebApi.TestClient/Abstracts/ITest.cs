using System;

namespace SelfHostedWebApi.TestClient.Abstracts
{
    public interface ITest : IDisposable
    {
        void Run();
    }
}
