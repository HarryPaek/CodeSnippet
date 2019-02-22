using SelfHostedWebApi.Common.Abstracts;
using System;
using System.Net.Http;

namespace SelfHostedWebApi.Client.Abstracts
{
    public interface IWebApiClient<T> : IDisposable
    {
        HttpResponseMessage Get(string serviceRoute);
        HttpResponseMessage Post(string serviceRoute, T item);
        HttpResponseMessage Put(string serviceRoute, T updateInfo);
        HttpResponseMessage Delete(string serviceRoute);
    }
}
