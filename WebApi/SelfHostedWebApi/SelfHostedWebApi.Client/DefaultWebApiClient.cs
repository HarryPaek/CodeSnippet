using SelfHostedWebApi.Client.Abstracts;
using SelfHostedWebApi.Common.Abstracts;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SelfHostedWebApi.Client
{
    public class DefaultWebApiClient<T> : IWebApiClient<T>
    {
        private readonly IWebApiConfigurationProvider _webApiConfiguration = null;
        private HttpClient _client = null;

        public DefaultWebApiClient(IWebApiConfigurationProvider webApiConfiguration)
        {
            if (webApiConfiguration == null)
                throw new ArgumentNullException("webApiConfiguration");

            this._webApiConfiguration = webApiConfiguration;
            InitClient();
        }

        private void InitClient()
        {
            this._client = new HttpClient();

            this._client.BaseAddress = new Uri(this._webApiConfiguration.BaseServiceAddress);
            this._client.DefaultRequestHeaders.Accept.Clear();
            this._client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpResponseMessage Delete(string serviceRoute)
        {
            var response = this._client.DeleteAsync(serviceRoute);
            response.Wait();

            return response.Result;
        }

        public HttpResponseMessage Get(string serviceRoute)
        {
            var response = this._client.GetAsync(serviceRoute);
            response.Wait();

            return response.Result;
        }

        public HttpResponseMessage Post(string serviceRoute, T newItem)
        {
            var response = this._client.PostAsJsonAsync(serviceRoute, newItem);
            response.Wait();

            return response.Result;
        }

        public HttpResponseMessage Put(string serviceRoute, T updateInfo)
        {
            var response = this._client.PutAsJsonAsync(serviceRoute, updateInfo);
            response.Wait();

            return response.Result;
        }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            // GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposing) {
                if (this._client != null) {
                    this._client.Dispose();
                    this._client = null;
                }
            }
        }

        #endregion
    }
}
