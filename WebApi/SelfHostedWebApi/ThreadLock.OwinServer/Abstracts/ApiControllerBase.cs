using ePlatform.Data.Abstracts;
using ePlatform.WebApi.Abstracts;
using System.Net.Http;

namespace ThreadLock.OwinServer.Abstracts
{
    public abstract class ApiControllerBase<TId, TItem> : AbstractControllerBase<TId, TItem> where TItem : IBaseEntity<TId>
    {
        #region Protected Methods

        protected override string ClientIpAddress
        {
            get
            {
                var request = Request;
                return request.GetOwinContext().Request.RemoteIpAddress;
            }
        }

        #endregion
    }
}
