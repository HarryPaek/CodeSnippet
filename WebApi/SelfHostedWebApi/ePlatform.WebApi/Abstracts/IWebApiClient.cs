using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ePlatform.WebApi.Abstracts
{
    public interface IWebApiClient<T> : IDisposable
    {
        HttpRequestHeaders DefaultRequestHeaders { get; }

        HttpResponseMessage Get(string serviceRoute);
        HttpResponseMessage Post(string serviceRoute, T item);
        HttpResponseMessage Put(string serviceRoute, T updateInfo);
        HttpResponseMessage Delete(string serviceRoute);
    }
}
