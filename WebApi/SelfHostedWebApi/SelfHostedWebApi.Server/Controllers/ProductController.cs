using SelfHostedWebApi.Data.Abstracts;
using SelfHostedWebApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SelfHostedWebApi.Server.Controllers
{
    public class ProductController: ApiController
    {
        private readonly IRepository<Product> _repository = null;

        public ProductController(IRepository<Product> repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            this._repository = repository;
        }

        #region WebAPI Methods

        // GET api/product 
        public IEnumerable<Product> Get()
        {
            return this._repository.GetAll();
        }

        // GET api/product/5 
        public Product Get(int id)
        {
            return this._repository.Get(id);
        }

        // POST api/product 
        public int Post([FromBody]Product product)
        {
            return this._repository.Add(product);
        }

        // PUT api/product/5 
        public bool Put(int id, [FromBody]Product product)
        {
            return this._repository.Update(id, product);
        }

        // DELETE api/product/5 
        public bool Delete(int id)
        {
            return this._repository.Delete(id);
        }

        #endregion
    }
}
