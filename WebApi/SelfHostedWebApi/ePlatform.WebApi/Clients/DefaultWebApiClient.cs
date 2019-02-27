using ePlatform.WebApi.Abstracts;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ePlatform.WebApi.Clients
{
    public class DefaultWebApiClient<T> : IWebApiClient<T>
    {
        private IWebApiConfigurationProvider _webApiConfiguration = null;
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

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue) {
                if (disposing) {
                    if (this._client != null) {
                        this._client.Dispose();
                        this._client = null;
                    }

                    this._webApiConfiguration = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~DefaultWebApiClient() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        #endregion
    }
}
