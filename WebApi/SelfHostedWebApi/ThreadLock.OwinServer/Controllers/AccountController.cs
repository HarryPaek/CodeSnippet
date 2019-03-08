using ePlatform.Data.Abstracts;
using log4net;
using System;
using System.Web.Http;
using ThreadLock.Data.Abstracts;
using ThreadLock.Data.Exceptions;
using ThreadLock.Data.Models;
using ThreadLock.OwinServer.Abstracts;

namespace ThreadLock.OwinServer.Controllers
{
    public sealed class AccountController : ApiControllerBase<string, Account>
    {
        private readonly ILog _logger = null;
        private readonly IAccountRepository _repository = null;

        public AccountController(IAccountRepository repository, ILog logger): base(logger)
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
        [Route("~/api/account/{id}/balance")]
        public IHttpActionResult GetBalance(string id)
        {
            try
            {
                return Ok(this._repository.GetBalance(id, this.Requester));
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

        [HttpGet]
        [Route("~/api/account/{id}/deposit/{amount:decimal}")]
        public IHttpActionResult DoDeposit(string id, decimal amount)
        {
            try
            {
                return Ok(this._repository.DoDeposit(id, amount, this.Requester));
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

        [HttpGet]
        [Route("~/api/account/{id}/withdraw/{amount:decimal}")]
        public IHttpActionResult DoWithdraw(string id, decimal amount)
        {
            try
            {
                return Ok(this._repository.DoWithdraw(id, amount, this.Requester));
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

        #region ApiControllerBase Implementations

        protected override IRepository<string, Account> Repository
        {
            get { return this._repository; }
        }

        #endregion
    }
}
