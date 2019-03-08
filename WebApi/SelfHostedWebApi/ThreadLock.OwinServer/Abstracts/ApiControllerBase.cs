using ePlatform.Data.Abstracts;
using ePlatform.WebApi.Abstracts;
using log4net;
using System.Net.Http;

namespace ThreadLock.OwinServer.Abstracts
{
    public abstract class ApiControllerBase<TId, TItem> : AbstractControllerBase<TId, TItem> where TItem : IBaseEntity<TId>
    {
        private readonly ILog _logger = null;

        public ApiControllerBase(ILog logger): base(logger)
        {
            this._logger = logger;
        }

        #region Protected Methods

        protected override string ClientIpAddress
        {
            get
            {
                var request = Request;
                string ipAddress = request.GetOwinContext().Request.RemoteIpAddress;

                if (this._logger != null && this._logger.IsDebugEnabled)
                    this._logger.DebugFormat("ClientIpAddress = [{0}]", ipAddress);

                return ipAddress;
            }
        }

        #endregion
    }
}
