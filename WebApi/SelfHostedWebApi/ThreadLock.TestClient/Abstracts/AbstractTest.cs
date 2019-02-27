using ePlatform.WebApi.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadLock.Data.Models;

namespace ThreadLock.TestClient.Abstracts
{
    public abstract class AbstractTest : ITest
    {
        #region ITest Implementations

        public bool RandomTest { get; set; }

        public void Run()
        {
            if (this.RandomTest)
                RunRandomTest();
            else
                RunFullTest();
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            // GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        #endregion

        #region Protected Properties

        protected abstract IWebApiClient<Account> Client { get; }

        #endregion

        #region Protected Test Case Methods

        protected void GetAllProducts()
        {
            HttpResponseMessage response = this.Client.Get("api/product");

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(string.Format("GetAllProducts(), Error with [{0}]", response.ReasonPhrase));

                return;
            }

            var products = response.Content.ReadAsAsync<IEnumerable<Product>>().Result
                                                                               .OrderBy(p => p.Id)
                                                                               .ToList();

            if (products.Any())
            {
                Console.WriteLine("GetAllProducts(), Displaying all the products...");
                products.ForEach(p =>
                {
                    maxProductId = p.Id;
                    Console.WriteLine(p);
                });

                Console.WriteLine();
            }
        }

        protected void GetProduct()
        {
            int productId = GetRandomProductId();
            HttpResponseMessage response = QueryProduct(productId);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(string.Format("GetProduct({0}), Error with [{1}]", productId, response.ReasonPhrase));

                return;
            }

            var product = response.Content.ReadAsAsync<Product>().Result;
            Console.WriteLine("Displaying product having [{0}]", product);
        }

        protected void AddProduct()
        {
            HttpResponseMessage response = this.Client.Post("api/product", GetNewProductItem());

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(string.Format("AddProduct(), Error with [{0}]", response.ReasonPhrase));

                return;
            }

            var productId = response.Content.ReadAsAsync<int>().Result;
            maxProductId = productId;
            Console.WriteLine("New Product Id=[{0}] added successfully.", productId);
        }

        protected void EditProduct()
        {
            int productId = GetRandomProductId();
            HttpResponseMessage response = QueryProduct(productId);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(string.Format("EditProduct(), QueryProduct({0}) error with [{1}]", productId, response.ReasonPhrase));

                return;
            }

            var product = response.Content.ReadAsAsync<Product>().Result;
            response = this.Client.Put(string.Format("api/product/{0}", product.Id), GetEditProductItem(product));

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(string.Format("EditProduct({0}), Error with [{1}]", product.Id, response.ReasonPhrase));

                return;
            }

            Console.WriteLine("Product Id=[{0}] updated successfully.", product.Id);
        }

        protected void DeleteProduct()
        {
            int deleteProductId = GetRandomProductId();

            Console.WriteLine("DeleteProduct(), deleteProductId=[{0}], maxProductId=[{1}]", deleteProductId, this.maxProductId);
            HttpResponseMessage response = this.Client.Delete(string.Format("api/product/{0}", deleteProductId));

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(string.Format("DeleteProduct({0}), Error with [{1}]", deleteProductId, response.ReasonPhrase));

                return;
            }

            Console.WriteLine("Product Id=[{0}] deleted successfully.", deleteProductId);
        }

        #endregion

        #region Private Methods

        private HttpResponseMessage QueryProduct(int productId)
        {
            return this.Client.Get(string.Format("api/product/{0}", productId));
        }

        /// <summary>
        /// 일부러 10번 이하는 삭제하거나 변경하지 않기 위하여 11번 부터 선택하는 것으로 함
        /// </summary>
        /// <returns></returns>
        private int GetRandomProductId()
        {
            return new Random().Next(11, this.maxProductId + 1);
        }

        private Product GetNewProductItem()
        {
            return new Product
            {
                Name = string.Format("Product {0} Name", maxProductId + 1),
                Description = string.Format("Product {0} Description", maxProductId + 1),
            };
        }

        private Product GetEditProductItem(Product product)
        {
            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = string.Format("{0}@1", product.Description),
            };
        }

        #endregion
    }
}
