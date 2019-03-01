using System;

namespace ThreadLock.TestClient.Abstracts
{
    public interface ITest : IDisposable
    {
        string Requester { get; set; }

        bool RandomTest { get; set; }

        void Run();
    }
}
