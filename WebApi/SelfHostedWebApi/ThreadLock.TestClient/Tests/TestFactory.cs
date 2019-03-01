using System;
using ThreadLock.TestClient.Abstracts;

namespace ThreadLock.TestClient.Tests
{
    public class TestFactory : ITest
    {
        private ITest _testCase = null;

        public TestFactory(ITest testCase)
        {
            if (testCase == null)
                throw new ArgumentNullException("testCase");

            this._testCase = testCase;
        }

        #region ITest Implementations

        private string _requester = string.Empty;

        public virtual string Requester
        {
            get { return string.IsNullOrWhiteSpace(this._requester) ? "TestFactory" : this._requester; }
            set { this._requester = value ?? string.Empty; }
        }

        public virtual bool RandomTest { get; set; }

        public virtual void Run()
        {
            this._testCase.Run();
        }

        #endregion

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue) {
                if (disposing) {
                    if (this._testCase != null) {
                        this._testCase.Dispose();
                        this._testCase = null;
                    }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~TestFactory() {
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
