using System;

namespace ThreadLock.TestClient.Abstracts
{
    public interface ITest : IDisposable
    {
        bool RandomTest { get; set; }

        void Run();
    }
}
