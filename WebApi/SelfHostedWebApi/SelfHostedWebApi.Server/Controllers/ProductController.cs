using SelfHostedWebApi.Data.Abstracts;
using SelfHostedWebApi.Data.Models;
using SelfHostedWebApi.Server.Abstracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace SelfHostedWebApi.Server.Controllers
{
    public class ProductController: ApiControllerBase
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
        public IHttpActionResult Get(int id)
        {
            Product product = this._repository.Get(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // POST api/product 
        public IHttpActionResult Post([FromBody]Product product)
        {
            int newId = this._repository.Add(product);

            return Ok(newId);
        }

        // PUT api/product/5 
        public IHttpActionResult Put(int id, [FromBody]Product product)
        {
            bool success = this._repository.Update(id, product);

            if (!success)
                return NotFound();

            return Ok();
        }

        // DELETE api/product/5 
        public IHttpActionResult Delete(int id)
        {
            bool success = this._repository.Delete(id);

            if (!success)
                return NotFound();

            return Ok();
        }

        #endregion
    }
}
