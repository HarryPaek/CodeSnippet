using System;

namespace ePlatform.WebApi.Abstracts
{
    public interface IWebApiServer : IDisposable
    {
        void Start();
        void End();
    }
}
