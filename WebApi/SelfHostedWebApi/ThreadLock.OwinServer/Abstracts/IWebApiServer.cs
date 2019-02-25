using System;

namespace ThreadLock.OwinServer.Abstracts
{
    public interface IWebApiServer : IDisposable
    {
        void Start();
        void End();
    }
}
