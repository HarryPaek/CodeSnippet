using ePlatform.Data.Abstracts;
using ePlatform.Data.Repositories;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using ThreadLock.Data.Abstracts;
using ThreadLock.Data.Models;
using ThreadLock.OwinServer.Abstracts;

namespace ThreadLock.OwinServer.Controllers
{
    public sealed class OpcUaServiceController: ApiControllerBase<string, OpcUaServiceRequest>
    {
        private readonly ILog _logger = null;
        private readonly IOpcUaServiceRepository _repository = null;

        public OpcUaServiceController(ILog logger): base(logger)
        {
            if (logger == null)
                throw new ArgumentNullException("logger");

            this._logger = logger;
            this._repository = new OpcUaServiceRepository(logger);
        }

        #region ApiControllerBase Implementations

        protected override IRepository<string, OpcUaServiceRequest> Repository
        {
            get { return this._repository; }
        }

        #endregion
    }

    internal class OpcUaServiceRepository : AbstractRepositoryBase<string, OpcUaServiceRequest>, IOpcUaServiceRepository
    {
        private readonly object _opcUaServicLock = new object();

        private List<OpcUaServiceRequest> _internalData = new List<OpcUaServiceRequest>
        {
            new OpcUaServiceRequest {Key = "Index-001", Value = 1.00 },
            new OpcUaServiceRequest {Key = "Index-002", Value = 2.00 },
            new OpcUaServiceRequest {Key = "Index-003", Value = 3.00 }
        };

        public OpcUaServiceRepository(ILog logger) : base(logger)
        {
        }

        protected override object LockObject
        {
            get { return _opcUaServicLock; }
        }

        protected override string AddInternal(OpcUaServiceRequest item)
        {
            this._internalData.Add(item);

            return item.Key;
        }

        protected override bool DeleteInternal(string id)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<OpcUaServiceRequest> GetAllInternal()
        {
            return this._internalData;
        }

        protected override OpcUaServiceRequest GetInternal(string id)
        {
            return this._internalData.FirstOrDefault(r => r.Key.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        protected override bool UpdateInternal(string id, OpcUaServiceRequest item)
        {
            throw new NotImplementedException();
        }
    }
}
