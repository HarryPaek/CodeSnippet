using SelfHostedWebApi.Client.Abstracts;
using SelfHostedWebApi.Data.Models;
using SelfHostedWebApi.TestClient.Abstracts;
using System;

namespace SelfHostedWebApi.TestClient.Tests
{
    public class SingleTest : AbstractProductTest
    {
        private IWebApiClient<Product> _client = null;

        public SingleTest(IWebApiClient<Product> client)
        {
            if (client == null)
                throw new ArgumentNullException("client");

            this._client = client;
        }

        #region ITest Implementations

        public override void Run()
        {
            GetAllProducts();
            GetProduct();
            AddProduct();
            EditProduct();
            DeleteProduct();
        }

        #endregion

        #region ITest Implementations

        protected override IWebApiClient<Product> Client
        {
            get { return this._client; }
        }

        #endregion

        #region overrided Methods

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (this._client != null) {
                    this._client.Dispose();
                    this._client = null;
                }
            }

            base.Dispose(disposing);
        }

        #endregion
    }
}
