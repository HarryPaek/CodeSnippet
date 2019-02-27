using ePlatform.WebApi.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadLock.Data.Models;
using ThreadLock.TestClient.Abstracts;

namespace ThreadLock.TestClient.Tests
{
    public class SingleTest : ITest
    {
        private IWebApiClient<Account> _client = null;

        public SingleTest(IWebApiClient<Account> client)
        {
            if (client == null)
                throw new ArgumentNullException("client");

            this._client = client;
        }

        #region ITest Implementation

        public bool RandomTest { get; set; }

        public void Run()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue) {
                if (disposing) {
                    // TODO: dispose managed state (managed objects).
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

        #endregion
    }
}
