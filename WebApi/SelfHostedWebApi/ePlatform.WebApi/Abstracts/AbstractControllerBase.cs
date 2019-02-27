using ePlatform.Data.Abstracts;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ePlatform.WebApi.Abstracts
{
    public abstract class AbstractControllerBase<TId, TItem> : ApiController where TItem : IBaseEntity<TId>
    {
        #region Public Default WebAPI Methods

        // GET api/{controller} 
        public virtual IEnumerable<TItem> Get()
        {
            return this.Repository.GetAll();
        }

        // GET api/{controller}/{id} 
        public virtual IHttpActionResult Get(TId id)
        {
            TItem item = this.Repository.Get(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // POST api/{controller} 
        public virtual IHttpActionResult Post([FromBody]TItem item)
        {
            TId newId = this.Repository.Add(item);

            return Ok(newId);
        }

        // PUT api/{controller}/{id}
        public virtual IHttpActionResult Put(TId id, [FromBody]TItem item)
        {
            bool success = this.Repository.Update(id, item);

            if (!success)
                return NotFound();

            return Ok();
        }

        // DELETE api/{controller}/{id}
        public virtual IHttpActionResult Delete(TId id)
        {
            bool success = this.Repository.Delete(id);

            if (!success)
                return NotFound();

            return Ok();
        }

        #endregion

        #region Protected Methods

        protected abstract IRepository<TId, TItem> Repository { get; }

        protected abstract string ClientIpAddress { get; }

        protected virtual string Requester
        {
            get
            {
                string requester = string.Empty;

                var request = Request;
                var headers = request.Headers;

                if (headers.Contains("Requester"))
                {
                    requester = headers.GetValues("Requester").FirstOrDefault();
                }

                if (string.IsNullOrWhiteSpace(requester))
                    requester = ClientIpAddress;

                return requester;
            }
        }

        #endregion
    }
}
