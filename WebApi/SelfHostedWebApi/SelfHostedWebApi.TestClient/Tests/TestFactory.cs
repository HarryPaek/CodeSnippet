using SelfHostedWebApi.TestClient.Abstracts;
using System;

namespace SelfHostedWebApi.TestClient.Tests
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

        public void Run()
        {
            this._testCase.Run();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        #endregion

        #region Protected Methods

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) {
                if (this._testCase != null) {
                    this._testCase.Dispose();
                    this._testCase = null;
                }
            }
        }

        #endregion
    }
}
