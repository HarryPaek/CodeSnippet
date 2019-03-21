using log4net;
using System;
using System.Web.Http;
using ThreadLock.Data.Abstracts;
using ThreadLock.Data.Exceptions;
using ThreadLock.Data.Models;

namespace ThreadLock.OwinServer.Controllers
{
    public sealed class EplanServiceController : ApiController
    {
        private readonly ILog _logger = null;
        private readonly IEplanServiceRepository _repository = null;

        public EplanServiceController(IEplanServiceRepository repository, ILog logger)
        {
            if (logger == null)
                throw new ArgumentNullException("logger");

            if (repository == null)
                throw new ArgumentNullException("repository");

            this._logger = logger;
            this._repository = repository;
        }

        #region Additional WebApi Methods

        [HttpGet]
        [Route("~/api/EplanService/StartEplan")]
        public IHttpActionResult StartEplan()
        {
            try
            {
                this._repository.StartEplan();
                return Ok();
            }
            catch (RepositoryDataNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("~/api/EplanService/SearchProject")]
        public IHttpActionResult SearchProject([FromBody]EplanServiceRequest request)
        {
            try
            {
                this._repository.ExceuteEplanAction(request);
                return Ok();
            }
            catch (RepositoryDataNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        #endregion
    }
}
