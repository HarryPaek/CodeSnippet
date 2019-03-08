using ePlatform.Data.Abstracts;
using log4net;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ePlatform.WebApi.Abstracts
{
    public abstract class AbstractControllerBase<TId, TItem> : ApiController where TItem : IBaseEntity<TId>
    {
        private readonly ILog _logger = null;

        public AbstractControllerBase(ILog logger)
        {
            this._logger = logger; 
        }

        #region Public Default WebAPI Methods

        // GET api/{controller} 
        public virtual IEnumerable<TItem> Get()
        {
            if (this._logger != null && this._logger.IsDebugEnabled)
                this._logger.Debug("Get(), GetAll()");

            return this.Repository.GetAll();
        }

        // GET api/{controller}/{id} 
        public virtual IHttpActionResult Get(TId id)
        {
            if (this._logger != null && this._logger.IsDebugEnabled)
                this._logger.DebugFormat("Get(), id = [{0}]", id);

            TItem item = this.Repository.Get(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // POST api/{controller} 
        public virtual IHttpActionResult Post([FromBody]TItem item)
        {
            if (this._logger != null && this._logger.IsDebugEnabled)
                this._logger.DebugFormat("Post(), item = [{0}]", item);

            TId newId = this.Repository.Add(item);

            return Ok(newId);
        }

        // PUT api/{controller}/{id}
        public virtual IHttpActionResult Put(TId id, [FromBody]TItem item)
        {
            if (this._logger != null && this._logger.IsDebugEnabled)
                this._logger.DebugFormat("Put(), id = [{0}], item = [{1}]", id, item);

            bool success = this.Repository.Update(id, item);

            if (!success)
                return NotFound();

            return Ok();
        }

        // DELETE api/{controller}/{id}
        public virtual IHttpActionResult Delete(TId id)
        {
            if (this._logger != null && this._logger.IsDebugEnabled)
                this._logger.DebugFormat("Delete(), id = [{0}]", id);

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

                if (headers.Contains("Requester")) {
                    requester = headers.GetValues("Requester").FirstOrDefault();
                }

                if (this._logger != null && this._logger.IsDebugEnabled)
                    this._logger.DebugFormat("Requester = [{0}]", requester);

                return string.Format("{0}@{1}", requester, ClientIpAddress);
            }
        }

        #endregion
    }
}
