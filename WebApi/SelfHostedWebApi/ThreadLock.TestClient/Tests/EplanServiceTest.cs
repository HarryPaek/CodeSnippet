using ePlatform.WebApi.Abstracts;
using log4net;
using System;
using System.Collections.Generic;
using System.Net.Http;
using ThreadLock.Data.Models;
using ThreadLock.TestClient.Abstracts;

namespace ThreadLock.TestClient.Tests
{
    public class EplanServiceTest : ITest
    {
        private ILog _logger = null;
        private IWebApiClient<EplanServiceRequest> _client = null;

        public EplanServiceTest(IWebApiClient<EplanServiceRequest> client, ILog logger)
        {
            if (logger == null)
                throw new ArgumentNullException("logger");

            if (client == null)
                throw new ArgumentNullException("client");

            this._logger = logger;
            this._client = client;
        }

        #region ITest Implementations

        private string _requester = string.Empty;

        public virtual string Requester
        {
            get { return string.IsNullOrWhiteSpace(this._requester) ? "EplanServiceTest" : this._requester; }
            set { this._requester = value ?? string.Empty; }
        }

        public virtual bool RandomTest { get; set; }

        public virtual void Run()
        {
            this._client.DefaultRequestHeaders.Add("Requester", this.Requester);

            RunTest();
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

                    this._logger = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~SingleTest() {
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

        #region Private Methods

        private void RunTest()
        {
            StartEplan();
            SearchProject();
        }

        #region Random Test Case Methods

        private void StartEplan()
        {
            HttpResponseMessage response = this._client.Get("api/EplanService/StartEplan");

            if (!response.IsSuccessStatusCode) {
                Console.WriteLine(string.Format("StartEplan(), Error with [{0}]", response.ReasonPhrase));

                if (this._logger.IsErrorEnabled)
                    this._logger.Error(response);

                return;
            }

            Console.WriteLine("StartEplan(), succcessfully executed");
        }

        private void SearchProject()
        {
            EplanServiceRequest request = new EplanServiceRequest
            {
                Action = "Test Action",
                ProjectName = "Test Project",
                Parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("TagId", "Tag-Id"),
                    new KeyValuePair<string, string>("PortNumber", "Port-Number")
                }
            };

            HttpResponseMessage response = this._client.Post("api/EplanService/SearchProject", request);

            if (!response.IsSuccessStatusCode) {
                Console.WriteLine(string.Format("SearchProject(), Error with [{0}]", response.ReasonPhrase));

                if (this._logger.IsErrorEnabled)
                    this._logger.Error(response);

                return;
            }

            Console.WriteLine("SearchProject(), EplanServiceRequest = [{0}]with succcessfully executed", request);
        }

        #endregion

        #endregion
    }
}
