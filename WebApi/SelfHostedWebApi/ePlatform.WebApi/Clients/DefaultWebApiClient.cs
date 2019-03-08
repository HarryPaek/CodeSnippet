using ePlatform.WebApi.Abstracts;
using log4net;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ePlatform.WebApi.Clients
{
    public class DefaultWebApiClient<T> : IWebApiClient<T>
    {
        private ILog _logger = null;
        private IWebApiConfigurationProvider _webApiConfiguration = null;
        private HttpClient _client = null;

        public DefaultWebApiClient(IWebApiConfigurationProvider webApiConfiguration, ILog logger)
        {
            if (logger == null)
                throw new ArgumentNullException("logger");

            if (webApiConfiguration == null)
                throw new ArgumentNullException("webApiConfiguration");

            this._webApiConfiguration = webApiConfiguration;
            this._logger = logger;

            InitClient();
        }

        private void InitClient()
        {
            if (this._logger.IsDebugEnabled) {
                this._logger.DebugFormat(" Client is initializing at {0}", this._webApiConfiguration.BaseServiceAddress);
                this._logger.Debug(" ..... ..... .....");
            }


            this._client = new HttpClient();

            this._client.BaseAddress = new Uri(this._webApiConfiguration.BaseServiceAddress);
            this._client.DefaultRequestHeaders.Accept.Clear();
            this._client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (this._logger.IsDebugEnabled) {
                this._logger.Debug(" ..... ..... .....");
                this._logger.DebugFormat(" Client was initialized at {0}", this._webApiConfiguration.BaseServiceAddress);
            }
        }

        #region IWebApiClient implementation

        public virtual HttpRequestHeaders DefaultRequestHeaders
        {
            get { return this._client == null ? null : this._client.DefaultRequestHeaders; }
        }

        public virtual HttpResponseMessage Delete(string serviceRoute)
        {
            var response = this._client.DeleteAsync(serviceRoute);
            response.Wait();

            return response.Result;
        }

        public virtual HttpResponseMessage Get(string serviceRoute)
        {
            var response = this._client.GetAsync(serviceRoute);
            response.Wait();

            return response.Result;
        }

        public virtual HttpResponseMessage Post(string serviceRoute, T newItem)
        {
            var response = this._client.PostAsJsonAsync(serviceRoute, newItem);
            response.Wait();

            return response.Result;
        }

        public virtual HttpResponseMessage Put(string serviceRoute, T updateInfo)
        {
            var response = this._client.PutAsJsonAsync(serviceRoute, updateInfo);
            response.Wait();

            return response.Result;
        }

        #endregion

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
