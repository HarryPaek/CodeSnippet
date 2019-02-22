using System.Net.Http;
using System.Web.Http;

namespace SelfHostedWebApi.Server.Abstracts
{
    public abstract class ApiControllerBase : ApiController
    {
        protected string ClientIpAddress
        {
            get { return Request.GetOwinContext().Request.RemoteIpAddress; }
        }
    }
}
